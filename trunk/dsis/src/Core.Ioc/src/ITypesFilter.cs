using System;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  public interface ITypesFilter
  {
    bool Accept(Type type);
    bool Accept(Assembly a);
    bool Accept(string assemblyPath);
  }
}