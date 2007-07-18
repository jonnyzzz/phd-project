using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class EntropyGraphWeightCallback<T> : ILoopIteratorCallback<T> where T : ICellCoordinate<T>
  {
    private static readonly double LN2 = Math.Log(2);
    protected readonly Dictionary<NodePair<T>, double> myM = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer()); 
    private double myLoopsCount = 0;

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
          Add(prev.Coordinate, node.Coordinate, p);
        } else
        {
          first = node;
        }
        prev = node;
      }
      Add(prev.Coordinate, first.Coordinate, p);
    }

    protected IEnumerable<Pair<NodePair<T>, double>> Weights
    {
      get
      {
        foreach (KeyValuePair<NodePair<T>, double> pair in myM)
        {
          yield return new Pair<NodePair<T>, double>(pair.Key, pair.Value);
        }
      }
    }

    protected void Add(T from, T to, double p)
    {
      double d;
      NodePair<T> pair = new NodePair<T>(from, to);
      myM.TryGetValue(pair, out d);
      myM[pair] = d + p;
    }

    private static void Add(Dictionary<T, double> ds, T node, double v)
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

      Dictionary<T, double> values = new Dictionary<T, double>();

      foreach (KeyValuePair<NodePair<T>, double> pair in myM)
      {
        double val = pair.Value / myLoopsCount;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
        info.Tick(1.0);
      }

      info.Maximum += values.Count;
      foreach (double value in values.Values)
      {
        v += Entropy(value);
        info.Tick(1.0);
      }
      return v / LN2;
    }

    private static double Entropy(double d)
    {
      return Math.Abs(d) < 1e-5 ? 0.0 : d * Math.Log(d);
    }

    public Dictionary<NodePair<T>, double> M
    {
      get { return myM; }
    }

    public double LoopsCount
    {
      get { return myLoopsCount; }
      protected set { myLoopsCount = value; }
    }
  }
}