using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class EntropyGraphWeightCallback<T> : IGraphWeightSearchCallback<T> where T : ICellCoordinate<T>
  {
    private static readonly double LN2 = Math.Log(2);
    private Dictionary<NodePair<T>, double> myM = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer()); 
    private int myLoopsCount = 0;

    public void OnLoopFound(IList<INode<T>> loop)
    {
      myLoopsCount++;

      double p = 1.0/loop.Count;
      INode<T> prev = null;
      INode<T> first = null;
      foreach (INode<T> node in loop)
      {
        if (prev != null)
        {
          Add(prev, node, p);
        } else
        {
          first = node;
        }
        prev = node;
      }
      Add(prev, first, p);
    }

    private void Add(INode<T> from, INode<T> to, double p)
    {
      double d;
      NodePair<T> pair = new NodePair<T>(from, to);
      myM.TryGetValue(pair, out d);
      myM[pair] = d + p;
    }

    private static void Add(Dictionary<INode<T>, double> ds, INode<T> node, double v)
    {
      double b;
      ds.TryGetValue(node, out b);
      ds[node] = b + v;
    }
    
    public double ComputeAntropy(IProgressInfo info)
    {
      double v = 0;
      info.Minimum = 0;
      info.Maximum = myM.Count;

      Dictionary<INode<T>, double> values = new Dictionary<INode<T>, double>();

      foreach (KeyValuePair<NodePair<T>, double> pair in myM)
      {
        double val = pair.Value / myLoopsCount;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
        info.Tick(1.0);
      }

      info.Maximum += values.Count;
      foreach (KeyValuePair<INode<T>, double> pair in values)
      {
        v += Entropy(pair.Value);
        info.Tick(1.0);
      }
      return v;
    }

    private static double Entropy(double d)
    {
      return d * Math.Log(d) / LN2;
    }

    public Dictionary<NodePair<T>, double> M
    {
      get { return myM; }
    }

    public int LoopsCount
    {
      get { return myLoopsCount; }
    }
  }
}