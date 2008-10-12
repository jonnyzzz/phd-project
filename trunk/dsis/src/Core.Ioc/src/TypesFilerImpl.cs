using System;
using System.IO;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  public class TypesFilerImpl : ITypesFilter
  {
    public bool Accept(Type type)
    {      
      return Accept(type.Assembly) && type.AssemblyQualifiedName.Contains("DSIS");
    }

    public bool Accept(Assembly a)
    {
      return a.GetName().Name.Contains("DSIS");
    }

    public bool Accept(string assemblyPath)
    {
      var accept = Path.GetFileNameWithoutExtension(assemblyPath);
      return accept.Contains("DSIS") 
        && !accept.Contains(".Generated.") 
        && !accept.Contains("Test") 
        && !accept.Contains("Tests");
    }
  }
}