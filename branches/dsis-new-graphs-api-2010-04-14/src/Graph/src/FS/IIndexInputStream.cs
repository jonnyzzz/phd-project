using System;
using System.Collections.Generic;

namespace DSIS.Graph.FS
{
  public interface IIndexInputStream : IDisposable
  {
    IEnumerable<IndexEntry> ReadData();
    long Count { get; }
    IndexEntry GetAt(long index);
  }
}