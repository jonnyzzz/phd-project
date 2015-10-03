using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc.JC
{
  public interface IImplLoopup
  {
    IEnumerable<Type> GetImplementations(Type y);

    void RegisterImplementation(Type y);
  }
}