using System;
using System.Reflection;

namespace EugenePetrenko.Shared.Core.Ioc
{
  public class NoneTypesFilerImpl : ITypesFilter
  {
    public bool Accept(Type type)
    {
      return true;
    }

    public bool Accept(Assembly a)
    {
      return true;
    }

    public bool Accept(string assemblyPath)
    {
      return true;
    }
  }
}