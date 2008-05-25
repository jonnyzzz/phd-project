using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Spring.Assemblies
{
  public interface IAssemblyIncludeManager
  {
    void RegisterAssemblyLoaded(IAssemblyLoadListener listener);
    void RegisterAssemblies(IEnumerable<Assembly> assemblies);
  }
}