using System.Collections.Generic;

namespace DSIS.Spring.Service
{
  public interface IServiceProvider
  {
    T GetService<T>();

    IEnumerable<T> GetServices<T>();
  }
}