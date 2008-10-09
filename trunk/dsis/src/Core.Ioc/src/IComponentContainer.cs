using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  public interface IComponentContainer : IDisposable
  {
    T GetComponent<T>();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    IComponentContainer SubContainer<TInterface, TImplementation>()
      where TImplementation : ComponentImplemetationAttributeBase
      where TInterface : ComponentInterfaceAttributeBase;
  }
}