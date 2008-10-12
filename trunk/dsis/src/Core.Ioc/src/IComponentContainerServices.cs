using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc
{
  public interface IComponentContainerServices
  {
    IEnumerable<T> GetServices<T>();

    void RegisterServiceAdded<T>(Action<T> action);
  }
}