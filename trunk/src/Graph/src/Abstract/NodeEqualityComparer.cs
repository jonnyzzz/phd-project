using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class NodeEqualityComparer<TNode, TCell> : IEqualityComparer<TNode>
    where TNode : Node<TNode, TCell>
    where TCell : ICellCoordinate<TCell>
  {
    public static NodeEqualityComparer<TNode, TCell> INSTANCE = new NodeEqualityComparer<TNode, TCell>();

    public bool Equals(TNode x, TNode y)
    {
      return x.EqualsInternal(y);
    }

    public int GetHashCode(TNode obj)
    {
      return obj.HashCodeInternal;
    }
  }
}