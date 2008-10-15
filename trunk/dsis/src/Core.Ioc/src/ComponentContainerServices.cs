using System;
using System.Collections.Generic;
using Castle.MicroKernel;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class ComponentContainerServices<TComponentCollection> : IComponentContainerServices
    where TComponentCollection : ComponentCollectionAttributeBase
  {
    private readonly IKernel myKernel;
    private readonly MultiHashDictionary<Type, Type> myMultiServices = new MultiHashDictionary<Type, Type>();
    private readonly MultiHashDictionary<Type, Action<object>> myActions = new MultiHashDictionary<Type, Action<object>>();
    private readonly IComponentInterfaceLookup myLookup;

    public ComponentContainerServices(IKernel kernel, IComponentInterfaceLookup lookup)
    {
      myKernel = kernel;
      myLookup = lookup;

      myKernel.ComponentRegistered += ComponentRegistered;
      myKernel.ComponentUnregistered += ComponentUnregistered;
      myKernel.ComponentCreated += myKernel_ComponentCreated;
    }

    void myKernel_ComponentCreated(Castle.Core.ComponentModel model, object instance)
    {
      foreach (var type in myLookup.FindInterfaces<TComponentCollection>(model.Implementation))
      {
        HashSet<Action<object>> handler;
        if (myActions.TryGetValue(type, out handler))
        {
          foreach (var action in handler)
          {
            action(instance);
          }
        }
      }
    }

    private void ComponentUnregistered(string key, IHandler handler)
    {
      var impl = handler.ComponentModel.Implementation;
      foreach (var type in myLookup.FindInterfaces<TComponentCollection>(impl))
      {
        myMultiServices.RemoveValue(type, impl);
      }
    }

    private void ComponentRegistered(string key, IHandler handler)
    {
      var impl = handler.ComponentModel.Implementation;
      foreach (var type in myLookup.FindInterfaces<TComponentCollection>(impl))
      {
        myMultiServices.AddValue(type, impl);
      }
    }

    public IEnumerable<T> GetServices<T>()
    {
      AssertServiceCollection<T>();
      if (myMultiServices.ContainsKey(typeof(T)))
      {
        return myMultiServices[typeof (T)].Map(x => (T) myKernel[x]);
      } 
        
      return EmptyArray<T>.Instance;
    }

    private static void AssertServiceCollection<T>()
    {
      if (!typeof(T).IsDefined(typeof(TComponentCollection), false))
      {
        throw new Exception("Component interface " + typeof (T) + " should be marked with " +
                            typeof (TComponentCollection) + " attribute");
      }
    }

    public void RegisterServiceAdded<T>(Action<T> action)
    {
      AssertServiceCollection<T>();
      myActions.AddValue(typeof(T), x=>action((T)x));
    }
  }
}