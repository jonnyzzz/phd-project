using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  [EqualityComparer(typeof(NodePairEqualityComparer<>))]
  public struct NodePair<T> where T:ICellCoordinate<T>
  {
    private readonly static IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public readonly T From;
    public readonly T To;
    public readonly int Hash;


    public NodePair(T from, T to)
    {
      From = from;
      To = to;
      Hash = COMPARER.GetHashCode(From) + 131 * COMPARER.GetHashCode(To);
    }
  }

  internal class NodePairEqualityComparer<T> : IEqualityComparer<NodePair<T>>
  where T : ICellCoordinate<T>
  {
    private readonly static IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();

    public bool Equals(NodePair<T> x, NodePair<T> y)
    {
      return x.Hash == y.Hash &&
        COMPARER.Equals(x.From, y.From) &&
        COMPARER.Equals(x.To, y.To);
    }

    public int GetHashCode(NodePair<T> obj)
    {
      return obj.Hash;
    }
  }
}