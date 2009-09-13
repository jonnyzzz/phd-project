using System;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc
{
  public class AssemblyWithComponentsFilerImpl : ITypesFilter
  {
    public bool Accept(Type type)
    {
      return true;
    }

    public bool Accept(Assembly a)
    {
      return a.IsDefined<AssemblyWithComponentsAttribute>();
    }

    public bool Accept(string assemblyPath)
    {
      return true;
    }
  }
}