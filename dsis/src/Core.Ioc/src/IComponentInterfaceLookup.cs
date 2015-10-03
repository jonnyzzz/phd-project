using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc
{
  public interface IComponentInterfaceLookup
  {
    IEnumerable<Type> FindInterfaces<T>(Type type)
      where T : Attribute;
  }
}