using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  [ComponentInterface]
  public interface IComponentContainer : IDisposable, IStartableComponent
  {
    T GetComponent<T>();

    IEnumerable<T> GetComponents<T>();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    IComponentContainer SubContainer<TInterface, TCollectionInterface, TImplementation>()
      where TImplementation : ComponentImplemetationAttributeBase
      where TCollectionInterface : ComponentCollectionAttributeBase
      where TInterface : ComponentInterfaceAttributeBase;

    ITypesFilter Filter { get; }

    void RegisterComponent(object instance);
  }
}