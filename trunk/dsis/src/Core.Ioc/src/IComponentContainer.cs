using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  [ComponentInterface]
  public interface IComponentContainer : IDisposable
  {
    T GetComponent<T>();

    void Start();

    IEnumerable<T> GetComponents<T>();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    IComponentContainer SubContainer<TImplementation>()
      where TImplementation : ComponentImplementationAttributeBase;

    ITypesFilter Filter { get; }

    void RegisterComponent(object instance);
  }
}