using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class NonDuplicatedLoopIteratorCallback<T,C> : ILoopIteratorCallback<T> 
    where T : ICellCoordinate<T>
    where C : ILoopIteratorCallback<T>
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER =
      EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly C myCallback;
    private readonly Hashset<LoopData> myFoundLoops = new Hashset<LoopData>(LoopDataComparer.INSTANCE);

    public NonDuplicatedLoopIteratorCallback(C callback)
    {
      myCallback = callback;
    }

    public void OnLoopFound(IList<INode<T>> loop)
    {
      LoopData data = new LoopData(loop);
      if (myFoundLoops.AddIfNotReplace(ref data))
      {
        myCallback.OnLoopFound(loop);
      }
    }

    private class LoopData
    {
      public readonly IList<INode<T>> Loop;
      public readonly int Hash;

      public LoopData(IList<INode<T>> loop)
      {
        Loop = loop;
        Hash = 0;
        foreach (INode<T> node in loop)
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