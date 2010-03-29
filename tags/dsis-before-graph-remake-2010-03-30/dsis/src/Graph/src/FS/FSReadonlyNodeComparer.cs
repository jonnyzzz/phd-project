using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.FS
{
  public class FSReadonlyNodeComparer<TCell> : IEqualityComparer<FSReadonlyNode<TCell>> where TCell : ICellCoordinate
  {
    public bool Equals(FSReadonlyNode<TCell> x, FSReadonlyNode<TCell> y)
    {
      return x.Entry.EntryId == y.Entry.EntryId;
    }

    public int GetHashCode(FSReadonlyNode<TCell> obj)
    {
      var code = obj.Entry.EntryId;
      return (int) (code + (code >> 32));
    }
  }
}