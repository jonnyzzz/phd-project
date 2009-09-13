using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  [NoInheritContainer]
  public abstract class JComponentContainerBase : IComponentContainer
  {
    private readonly HashSet<Assembly> myAssemblies = new HashSet<Assembly>();
    private readonly JContainer myContainer;
    private readonly ITypesFilter myFilter;
    private readonly HashSet<IStartableComponent> myInitializedStartable = new HashSet<IStartableComponent>();
    private bool myIsDisposed;

    protected JComponentContainerBase(JContainer container, ITypesFilter filter)
    {
      myContainer = container;
      myFilter = filter;
    }

    public IEnumerable<Assembly> Assemblies
    {
      get { return myAssemblies; }
    }

    protected JContainer Container
    {
      get { return myContainer; }
    }

    public virtual IComponentService Start()
    {
      ScanAssemblies(new[] {GetType().Assembly});
      myContainer.RegisterInstance(this);

      var cmps = myContainer.GetComponents<IStartableComponent>();
      foreach (var cmp in cmps)
      {
        if (!myInitializedStartable.Contains(cmp) && cmp != this)
        {
          myInitializedStartable.Add(cmp);
          cmp.Start();
        }
      }
      return this;
    }

    public void Dispose()
    {
      if (myIsDisposed)
        return;
      myIsDisposed = true;

      var cmps = myContainer.GetCreatedComponentFromThatContainer<IDisposable>();
      foreach (IDisposable cmp in cmps)
      {
        if (cmp != this)
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

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      var toLoad = new HashSet<Assembly>(assemblies.Where(x => x != null));
      toLoad.RemoveWhere(x => myAssemblies.Contains(x));

      myAssemblies.UnionWith(toLoad);

      foreach (var assembly in toLoad)
      {
        LookupAssembly(assembly);
      }
    }

    protected abstract void LookupAssembly(Assembly assembly);

    protected abstract JComponentContainerBase CreateContainer<TImpl2>()
      where TImpl2 : ComponentImplementationAttributeBase;

    public IComponentContainerBuilder SubContainer<TImplementation>(params object[] instances)
      where TImplementation : ComponentImplementationAttributeBase
    {
      var child = SubContainerNoScan<TImplementation>(instances);
      child.ScanAssemblies(myAssemblies);
      return child;
    }

    public IComponentContainerBuilder SubContainerNoScan<TImplementation>(params object[] instances)
      where TImplementation : ComponentImplementationAttributeBase
    {
      var @base = CreateContainer<TImplementation>();
      instances.ForEach(@base.RegisterComponent);
      return new SubContainerBuilder(@base);
    }

    public ITypesFilter Filter
    {
      get { return myFilter; }
    }

    public void RegisterComponent(object instance)
    {
      myContainer.RegisterInstance(instance);
    }

    public void RegisterComponentType(Type t)
    {
      myContainer.RegisterComponent(t);
    }
  }
}