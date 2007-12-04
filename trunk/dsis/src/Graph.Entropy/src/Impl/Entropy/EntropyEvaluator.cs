using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class EntropyEvaluator<T, TPair>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>
  {
    private const double EPS = 1e-10;
    private static readonly double LN2 = Math.Log(2);

    protected readonly IDictionary<TPair, double> myM;
    protected readonly IEqualityComparer<T> myComparer;
    protected readonly double myNorm;

    public EntropyEvaluator(IDictionary<TPair, double> m, double norm, IEqualityComparer<T> comparer)
    {
      myNorm = norm;
      myM = m;
      myComparer = comparer;
    }
    
    public void ComputeEntropy(IEntropyListener<T> listener)
    {
      double v = 0;
      Dictionary<T, double> values = new Dictionary<T, double>(myComparer);

      foreach (KeyValuePair<TPair, double> pair in myM)
      {
        double val = pair.Value / myNorm;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
      }

      foreach (double value in values.Values)
      {
        v += Entropy(value);
      }

      listener.OnResult(v / LN2, values, myM);
    }

    protected static void Add<Q>(IDictionary<Q, double> ds, Q node, double v)
    {
      double b;
      if (ds.TryGetValue(node, out b))
        v += b;

      ds[node] = v;
    }
        
    private static double Log(double d)
    {
      return Math.Log(d);
    }

    private static double Entropy(double d)
    {
      if (d < EPS)
        return 0;

      return d * Log(d);
    }
  }
}