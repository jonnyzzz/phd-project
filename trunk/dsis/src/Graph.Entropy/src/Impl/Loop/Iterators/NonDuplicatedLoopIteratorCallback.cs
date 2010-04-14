using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class NonDuplicatedLoopIteratorCallback<T,N,C> : ILoopIteratorCallback<T, N> 
    where T : ICellCoordinate
    where C : ILoopIteratorCallback<T,N>
    where N : class, INode<T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER =
      EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly C myCallback;
    private readonly HashSet<LoopData> myFoundLoops = new HashSet<LoopData>(LoopDataComparer.INSTANCE);

    public NonDuplicatedLoopIteratorCallback(C callback)
    {
      myCallback = callback;
    }

    public void OnLoopFound(IEnumerable<N> loop, int length)
    {
      var data = new LoopData(loop);
      if (myFoundLoops.Add(data))
      {
        myCallback.OnLoopFound(loop, length);
      }
    }

    private class LoopData
    {
      public readonly IList<INode<T>> Loop;
      public readonly int Hash;

      public LoopData(IEnumerable<INode<T>> loop)
      {
        Loop = new List<INode<T>>(loop);
        Hash = 0;
        foreach (var node in Loop)
        {
          Hash += COMPARER.GetHashCode(node);
        }
      }
    }

    private class LoopDataComparer : IEqualityComparer<LoopData>
    {
      public static readonly IEqualityComparer<LoopData> INSTANCE = new LoopDataComparer();

      public bool Equals(LoopData x, LoopData y)
      {
        if (x.Loop.Count != y.Loop.Count)
          return false;

        for(int i = 0; i<x.Loop.Count; i++)
        {
          bool br = false;
          for(int j = 0; j <x.Loop.Count; j++)
          {
            if (!ReferenceEquals(x.Loop[j], y.Loop[(i + j) % x.Loop.Count]))
            {
              br = true;
              break;
            }
          }
          if (!br)
            return true;
        }
        return false;
      }

      public int GetHashCode(LoopData obj)
      {
        return obj.Hash * Primes.ByIndex(obj.Loop.Count);
      }
    }
  }
}