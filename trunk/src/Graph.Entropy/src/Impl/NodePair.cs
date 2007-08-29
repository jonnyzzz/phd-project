using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  [EqualityComparer(typeof (NodePairEqualityComparer<>))]
  public class NodePair<T> : PairBase<T> where T : ICellCoordinate<T>
  {
    public static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public readonly T From;
    public readonly int Hash;

    public NodePair(T from, T to) : this(from, HashValue(from), to)
    {
    }

    public NodePair(T from, int fromHash, T to) : this(from, fromHash, to, HashValue(to))
    {
    } 

    public NodePair(T from, int fromHash, T to, int toHash) : base(to)
    {
      From = from;
      Hash = fromHash + 131*toHash;
    }

    public static int HashValue(T t)
    {
      return COMPARER.GetHashCode(t);
    }


    public override string ToString()
    {
      return string.Format("{0} -> {1}", From, To);
    }
  }

  internal class NodePairEqualityComparer<T> : IEqualityComparer<NodePair<T>>
    where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = NodePair<T>.COMPARER;

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