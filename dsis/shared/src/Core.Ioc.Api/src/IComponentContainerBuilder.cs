using System;
using System.Collections.Generic;
using System.Reflection;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [NoInheritContainer]
  public interface IComponentContainerBuilder : IDisposable
  {
    IComponentService Start();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    void RegisterComponent(object instance);
    void RegisterComponentType(Type t);
  }
}