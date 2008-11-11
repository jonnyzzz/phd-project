using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  [NoInheritContainer]
  public interface IAssemblyScaner
  {
    IEnumerable<Pair<Type, T>> LoadTypes<T>(Assembly a) where T : Attribute;
  }
}