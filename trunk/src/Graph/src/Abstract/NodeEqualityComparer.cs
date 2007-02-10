using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class NodeEqualityComparer<TNode, TCell> : IEqualityComparer<TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private static IEqualityComparer<TCell> CellComparer = EqualityComparerFactory<TCell>.GetComparer();

    public static NodeEqualityComparer<TNode, TCell> INSTANCE = new NodeEqualityComparer<TNode, TCell>();

    public bool Equals(TNode x, TNode y)
    {
      return CellComparer.Equals(x.Coordinate, y.Coordinate);
    }

    public int GetHashCode(TNode obj)
    {
      return obj.HashCodeInternal;
    }
  }
}