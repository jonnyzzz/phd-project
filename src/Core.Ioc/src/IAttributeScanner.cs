using System;
using System.Collections.Generic;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc
{
  [NoInheritContainer]
  public interface IAttributeScanner
  {
    IEnumerable<Pair<Type, T>> LoadTypes<T>() where T : Attribute;
  }
}