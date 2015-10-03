using System.Reflection;

namespace DSIS.Spring.Assemblies
{
  public interface IAssemblyLoadListener
  {
    void AssemblyLoaded(Assembly assembly);
  }
}