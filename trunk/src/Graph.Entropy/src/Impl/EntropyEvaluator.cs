using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  public class PairBase<T>
    where T : ICellCoordinate<T>
  {
    public readonly T To;

    public PairBase(T to)
    {
      To = to;
    }
  }

  public static class EntropyEvaluator<T, TPair>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>
  {
    private static readonly double LN2 = Math.Log(2);

    public static void ComputeEntropy(IDictionary<TPair, double> m, double norm, IEntropyListener<T> listener)
    {
      double v = 0;

      Dictionary<T, double> values = new Dictionary<T, double>(EqualityComparerFactory<T>.GetComparer());

      foreach (KeyValuePair<TPair, double> pair in m)
      {
        double val = pair.Value / norm;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
      }

      foreach (double value in values.Values)
      {
        v += Entropy(value);
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