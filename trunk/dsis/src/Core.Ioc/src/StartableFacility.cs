using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.LifecycleConcerns;
using Castle.MicroKernel.ModelBuilder;

namespace DSIS.Core.Ioc
{
  public class StartableFacility<TComponentImpl> : IFacility
    where TComponentImpl : ComponentImplementationAttributeBase
  {
    private IKernel myKernel;
    private readonly List<IHandler> myWaitList = new List<IHandler>();

    public void Init(IKernel kernel, IConfiguration facilityConfig)
    {
      myKernel = kernel;
      kernel.ComponentModelBuilder.AddContributor(new StartableInspector());
      kernel.ComponentRegistered += OnComponentRegistered;
    }

    public void Terminate()
    {
      // Nothing to do

    }

    private void OnComponentRegistered(String key, IHandler handler)
    {
      var startable = handler.ComponentModel.ExtendedProperties["startable"];
      if (startable != null && (bool)startable)
      {
        if (handler.CurrentState == HandlerState.WaitingDependency)
        {
          myWaitList.Add(handler);
        }
        else
        {
          Start(handler.ComponentModel.Implementation);
        }
      }

      CheckWaitingList();
    }

    /// For each new component registered,
    /// some components in the WaitingDependency
    /// state may have became valid, so we check them
    private void CheckWaitingList()
    {
      foreach (var handler in new List<IHandler>(myWaitList))
      {
        if (handler.CurrentState == HandlerState.Valid)
        {
          Start(handler.ComponentModel.Implementation);

          myWaitList.Remove(handler);
        }
      }
    }

    /// Request the component instance

    private void Start(Type key)
    {
      myKernel.GetService(key);
    }

    private class StartableInspector : IContributeComponentModelConstruction
    {
      public void ProcessModel(IKernel kernel, ComponentModel model)
      {
        bool startable = IsStartable(model);

        model.ExtendedProperties["startable"] = startable;

        if (startable)
        {
          model.LifecycleSteps.Add(LifecycleStepType.Commission, new StartableConcern());
        }
      }

      private static bool IsStartable(ComponentModel model)
      {
        foreach (TComponentImpl attr in model.Implementation.GetCustomAttributes(typeof(TComponentImpl), true))
        {
          if (attr.Startable)
            return true;
        }
        return false;
      }

      private class StartableConcern : ILifecycleConcern
      {
        public void Apply(ComponentModel model, object component)
        {
          var x = (component as IStartableComponent);
          if (x != null)
          {
            x.Start();
          }
        }
      }
    }
  }
}