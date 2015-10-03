using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public interface ICountEnumerable<out T> : IEnumerable<T>
  {
    int Count { get;}
  }
}