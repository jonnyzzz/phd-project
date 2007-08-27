using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public static class EntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    private static readonly double LN2 = Math.Log(2);

    public static void ComputeEntropy(IDictionary<NodePair<T>, double> m, double norm, IProgressInfo info, IEntropyListener<T> listener)
    {
      double v = 0;
      info.Minimum = 0;
      info.Maximum = m.Count;

      Dictionary<T, double> values = new Dictionary<T, double>(EqualityComparerFactory<T>.GetComparer());

      foreach (KeyValuePair<NodePair<T>, double> pair in m)
      {
        double val = pair.Value / norm;
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

      listener.OnResult(v / LN2, values);
    }

    private static void Add(IDictionary<T, double> ds, T node, double v)
    {
      double b;
      ds.TryGetValue(node, out b);
      ds[node] = b + v;
    }


    private static double Entropy(double d)
    {
      return Math.Abs(d) < 1e-5 ? 0.0 : d * Math.Log(d);
    }

  }
}