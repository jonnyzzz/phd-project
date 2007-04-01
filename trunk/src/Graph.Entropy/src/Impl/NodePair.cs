using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  [EqualityComparer(typeof(NodePairEqualityComparer<>))]
  public struct NodePair<T> where T:ICellCoordinate<T>
  {
    private readonly static IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public readonly INode<T> From;
    public readonly INode<T> To;
    public readonly int Hash;

    public NodePair(INode<T> from, INode<T> to)
    {
      From = from;
      To = to;

      Hash = (COMPARER.GetHashCode(from.Coordinate) << 4) + 91 * COMPARER.GetHashCode(to.Coordinate);
    }
  }

  internal class NodePairEqualityComparer<T> : IEqualityComparer<NodePair<T>>
  where T : ICellCoordinate<T>
  {
    private readonly static IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public bool Equals(NodePair<T> x, NodePair<T> y)
    {
      return x.Hash == y.Hash &&
        COMPARER.Equals(x.From.Coordinate, y.From.Coordinate) &&
        COMPARER.Equals(x.To.Coordinate, y.To.Coordinate);
    }

    public int GetHashCode(NodePair<T> obj)
    {
      return obj.Hash;
    }
  }
}