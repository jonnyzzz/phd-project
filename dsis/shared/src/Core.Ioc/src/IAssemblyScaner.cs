using System;
using System.Collections.Generic;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc
{
  [NoInheritContainer]
  public interface IAssemblyScaner
  {
    IEnumerable<Pair<Type, T>> LoadTypes<T>(Assembly a) where T : Attribute;
  }
}