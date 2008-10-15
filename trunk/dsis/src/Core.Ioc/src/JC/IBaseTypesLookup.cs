using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc.JC
{
  public interface IBaseTypesLookup
  {
    IEnumerable<Type> GetBaseTypes(Type y);
  }
}