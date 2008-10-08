using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  public interface IComponentContainer
  {
    void ScanAssemblies(IEnumerable<Assembly> assemblies);
  }
}