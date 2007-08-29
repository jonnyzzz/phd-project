using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  [EqualityComparer(typeof(JVRPairEqualityComparer<>))]
  public class JVRPair<T> : PairBase<T> where T : ICellCoordinate<T>
  {
    public static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public readonly T From;
    public readonly int Hash;
    public readonly int BackHash;

    public JVRPair(T from, T to) : this(from, HashValue(from), to)
    {
    }

    public JVRPair(T from, int fromHash, T to) : this(from, fromHash, to, HashValue(to))
    {
    } 

    public JVRPair(T from, T to, int toHash) : this(from, HashValue(from), to, toHash)
    {      
    }

    public JVRPair(T from, int fromHash, T to, int toHash) : this(from, to, HashValue(fromHash, toHash), HashValue(toHash, fromHash))
    {
      From = from;      
      Hash = fromHash + 131*toHash;
      Hash = toHash + 131*fromHash;
    }

    private static int HashValue(int a, int b)
    {
      return a + 131*b;
    }

    private JVRPair(T from, T to, int hash, int backHash) : base(to)
    {
      From = from;
      Hash = hash;
      BackHash = backHash;
    }

    public static int HashValue(T t)
    {
      return COMPARER.GetHashCode(t);
    }

    public override string ToString()
    {
      return string.Format("{0} -> {1}", From, To);
    }

    public JVRPair<T> Inverse()
    {
      return new JVRPair<T>(To, From, BackHash, Hash);
    }
  }

  internal class JVRPairEqualityComparer<T> : IEqualityComparer<JVRPair<T>>
  where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = NodePair<T>.COMPARER;

    public bool Equals(JVRPair<T> x, JVRPair<T> y)
    {
      return x.Hash == y.Hash &&
             COMPARER.Equals(x.From, y.From) &&
             COMPARER.Equals(x.To, y.To);
    }

    public int GetHashCode(JVRPair<T> obj)
    {
      return obj.Hash;
    }
  }

}