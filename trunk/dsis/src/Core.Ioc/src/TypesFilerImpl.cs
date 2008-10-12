using System;
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
  }
}