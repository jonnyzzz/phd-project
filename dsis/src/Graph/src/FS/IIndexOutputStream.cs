using System;

namespace DSIS.Graph.FS
{
  public interface IIndexOutputStream : IDisposable
  {
    void WriteBlockStartLocation(IndexEntry entry);
  }
}