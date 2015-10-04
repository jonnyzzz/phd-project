using System;
using System.Collections.Generic;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class SubContainerBuilder : IComponentContainerBuilder
  {
    private readonly IComponentContainer myContainer;
    private bool myIsStarted;

    public SubContainerBuilder(IComponentContainer container)
    {
      myContainer = container;
    }

    public void Dispose()
    {
      if (!myIsStarted)
      {
        myContainer.Dispose();       
      }
    }

    public IComponentService Start()
    {
      myIsStarted = true;
      myContainer.Start();
      return myContainer;
    }

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      myContainer.ScanAssemblies(assemblies);
    }

    public void RegisterComponent(object instance)
    {
      myContainer.RegisterComponent(instance);
    }

    public void RegisterComponentType(Type t)
    {
      myContainer.RegisterComponentType(t);
    }
  }
}