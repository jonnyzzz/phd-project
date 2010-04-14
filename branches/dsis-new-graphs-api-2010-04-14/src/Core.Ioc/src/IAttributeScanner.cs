using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  [NoInheritContainer]
  public interface IAttributeScanner
  {
    IEnumerable<Pair<Type, T>> LoadTypes<T>() where T : Attribute;
  }
}