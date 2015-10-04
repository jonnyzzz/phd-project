using System;
using System.Reflection;

namespace EugenePetrenko.Shared.Core.Ioc
{
  public interface ITypesFilter
  {
    bool Accept(Type type);
    bool Accept(Assembly a);
    bool Accept(string assemblyPath);
  }
}