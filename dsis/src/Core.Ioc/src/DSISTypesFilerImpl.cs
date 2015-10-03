using System;
using System.IO;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  public class DSISTypesFilerImpl : ITypesFilter
  {
    public bool Accept(Type type)
    {
      //Allow hawing implementation of some interface from non-DSIS library
      //Allow all types from DSIS library
      return type.AssemblyQualifiedName.Contains("DSIS") 
        || (type.IsInterface);
    }

    public bool Accept(Assembly a)
    {
      //Any assembly with DSIS in name, even test assembly
      return a.GetName().Name.Contains("DSIS");
    }

    public bool Accept(string assemblyPath)
    {
      var accept = Path.GetFileNameWithoutExtension(assemblyPath);
      return AcceptAssemblyName(accept);
    }

    private static bool AcceptAssemblyName(string accept)
    {
      return accept.Contains("DSIS") 
             && !accept.Contains(".Generated.") 
             && !accept.Contains("Test") 
             && !accept.Contains("Tests");
    }
  }
}