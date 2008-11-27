using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc
{
  [Obsolete("User IComponentContainer")]
  [NoInheritContainer]
  public interface IComponentContainerServices
  {
    IEnumerable<T> GetServices<T>();  
  }
}