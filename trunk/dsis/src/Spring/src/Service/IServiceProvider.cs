using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;

namespace DSIS.Spring.Service
{
  [Obsolete("Check"), ComponentInterface]
  public interface IServiceProvider
  {
    T GetService<T>();

    IEnumerable<T> GetServices<T>();
  }
}