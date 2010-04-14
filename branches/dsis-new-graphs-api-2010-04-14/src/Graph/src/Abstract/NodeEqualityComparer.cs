using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  //TODO: Introduce long nodeId and compare nodes by id, not by TCell
  public class NodeEqualityComparer<TNode, TCell> : IEqualityComparer<TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate
  {
    private static readonly IEqualityComparer<TCell> CellComparer = EqualityComparerFactory<TCell>.GetComparer();

    public bool Equals(TNode x, TNode y)
    {
      return x.HashCodeInternal == y.HashCodeInternal && CellComparer.Equals(x.Coordinate, y.Coordinate);
    }

    public int GetHashCode(TNode obj)
    {
      return obj.HashCodeInternal;
    }
  }
}