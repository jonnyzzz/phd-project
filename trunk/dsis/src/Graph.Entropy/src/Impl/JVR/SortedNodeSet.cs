using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class SortedNodeSet<T> : BinTreePriorityQueueEx<T,double> 
    where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<T> COMPARER = EqualityComparerFactory<T>.GetComparer();
    private readonly Dictionary<T, Node> myValues = new Dictionary<T, Node>(COMPARER);
    private double myCurrentError = 0;

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

      var value = output - input;
      
      AddNode(value, node);      
    }


    protected override void NodeAdded(Node node)
    {
      base.NodeAdded(node);
      myValues.Add(node.Data, node);
      myCurrentError += Math.Abs(node.Value);
    }

    protected override void NodeRemoved(Node node)
    {
      base.NodeRemoved(node);
      myCurrentError -= Math.Abs(node.Value);
      myValues.Remove(node.Data);
    }

    public double SummaryError
    {
      get { return myCurrentError; }
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