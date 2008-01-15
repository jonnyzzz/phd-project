using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  [EqualityComparer(typeof(JVRPairEqualityComparer<>))]
  public class JVRPair<T> : PairBase<T> 
    where T : ICellCoordinate
  {
    public static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    public readonly int Hash;

    public JVRPair(T from, T to) : this(from, HashValue(from), to)
    {
    }

    private JVRPair(T from, int fromHash, T to) : base(from, to)
    {    
      Hash = HashValue(fromHash, HashValue(to));      
    }
    
    private static int HashValue(int a, int b)
    {
      return a + 131*b;
    }

    private static int HashValue(T t)
    {
      return COMPARER.GetHashCode(t);
    }

    public static JVRPairFactory Factory(T from)
    {
      return new JVRPairFactory(from);
    }

    public class JVRPairFactory
    {
      private readonly T myNode;
      private readonly int myHash;

      public JVRPairFactory(T node)
      {
        myNode = node;
        myHash = HashValue(node);
      }

      public JVRPair<T> Create(T nodeTo)
      {
        return new JVRPair<T>(myNode, myHash, nodeTo);
      }
    }
  }

  internal class JVRPairEqualityComparer<T> : IEqualityComparer<JVRPair<T>>
  where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = JVRPair<T>.COMPARER;

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