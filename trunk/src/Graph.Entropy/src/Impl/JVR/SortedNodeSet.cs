using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class SortedNodeSet<T> : BinTreePriorityQueueExDebugDouble<T> where T : ICellCoordinate<T>
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    private readonly Dictionary<T, Node> myValues = new Dictionary<T, Node>(COMPARER);

    public SortedNodeSet() : base(new Comparer())
    {
    }

    public void SetValue(T node, double output, double input)
    {
      Node v;
      if (myValues.TryGetValue(node, out v))
      {
        Remove(v);
        myValues.Remove(node);
      }

      myValues.Add(node, AddNode(output - input, node));      
    }

    private void AddValue(T node, double value)
    {
      Node v;
      if (myValues.TryGetValue(node, out v))
      {
        value += v.Value;
        Remove(v);
        myValues.Remove(node);
      }

      myValues.Add(node, AddNode(value, node));
    }

    public void Add(JVRPair<T> pair, double v)
    {
      AddValue(pair.From, -v);
      AddValue(pair.To, v);
    }

    public T NextNode()
    {
      Pair<T, double> min = ExtractMin();
      myValues.Remove(min.First);
      return min.First;
    }

    private class Comparer : IComparer<double>
    {
      public int Compare(double x, double y)
      {
        x = Math.Abs(x);
        y = Math.Abs(y);

        if (x < y)
          return 1;
        if (x > y)
          return -1;
        return 0;
      }
    }
  }
}