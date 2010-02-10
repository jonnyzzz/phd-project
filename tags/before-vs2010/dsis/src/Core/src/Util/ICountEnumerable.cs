using System.Collections.Generic;

namespace DSIS.Core.Util
{
  public interface ICountEnumerable<T> : IEnumerable<T>
  {
    int Count { get;}
  }
}