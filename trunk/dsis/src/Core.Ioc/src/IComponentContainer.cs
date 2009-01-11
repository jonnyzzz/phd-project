using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Core.Ioc.JC;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  [ComponentInterface]
  public interface IComponentContainer : IDisposable, ISubContainerFactory
  {
    T GetComponent<T>();

    void Start();

    IEnumerable<T> GetComponents<T>();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    ITypesFilter Filter { get; }

    void RegisterComponent(object instance);

    void RegisterComponentType(Type t);
  }

  public interface ISubContainerFactory
  {
    IComponentContainer SubContainer<TImplementation>()
      where TImplementation : ComponentImplementationAttributeBase;
  }

  [NoInheritContainer]
  public interface ITypeInstantiator
  {
    T Instanciate<T>(params object[] instances);
  }

  [JContainerPredefinedComponent, NoInheritContainer]
  public class TypeInstantiatorImpl : ITypeInstantiator
  {
    [Autowire]
    public IComponentContainer Container { get; set; }

    public T Instanciate<T>(params object[] instances)
    {
      var c = Container.SubContainer<FakeComponent>();
      instances.Each(c.RegisterComponent);
      return c.GetComponent<T>();
    }

    private class FakeComponent : ComponentCollectionAttributeBase {}
  }
}