using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc.JC {

  public abstract class JComponentContainerBase : IComponentContainer    
  {
    private readonly HashSet<Assembly> myAssemblies = new HashSet<Assembly>();
    private readonly JContainer myContainer;
    private readonly ITypesFilter myFilter;

    protected JComponentContainerBase(JContainer container, ITypesFilter filter)
    {
      myContainer = container;
      myFilter = filter;
    }

    public void Start()
    {
      var cmps = myContainer.GetComponents<IStartableComponent>();
      foreach (var cmp in cmps)
      {
        cmp.Start();
      }
    }

    public void Dispose()
    {
      var cmps = myContainer.GetComponents<IDisposable>();
      foreach (var cmp in cmps)
      {
        cmp.Dispose();
      }
    }

    public T GetComponent<T>()
    {
      return myContainer.GetComponent<T>();
    }

    public IEnumerable<T> GetComponents<T>()
    {
      return myContainer.GetComponents<T>();
    }

    public abstract void ScanAssemblies(IEnumerable<Assembly> assemblies);
    public abstract IComponentContainer SubContainer<TInterface, TCollectionInterface, TImplementation>() where TInterface : ComponentInterfaceAttributeBase where TCollectionInterface : ComponentCollectionAttributeBase where TImplementation : ComponentImplemetationAttributeBase;

    public ITypesFilter Filter
    {
      get { return myFilter; }
    }

    public void RegisterComponent(object instance)
    {
      myContainer.RegisterInstance(instance);
    }
  }
}