using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc
{
  [Obsolete("Use IComponentContainer")]
  [NoInheritContainer]
  public interface IComponentContainerServices
  {
    IEnumerable<T> GetServices<T>();  
  }
}