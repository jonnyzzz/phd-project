using System;
using System.Collections.Generic;

namespace DSIS.Spring.Service
{
  [Obsolete("Check")]
  public interface IServiceProvider
  {
    T GetService<T>();

    IEnumerable<T> GetServices<T>();
  }
}