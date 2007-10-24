using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class EntropyEvaluator<T, TPair> : IEntropyProcessor<T>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>
  {    
    private static readonly double LN2 = Math.Log(2);

    private readonly IDictionary<TPair, double> myM;
    private readonly double myNorm;
    private readonly IEqualityComparer<T> myComparer;

    public EntropyEvaluator(IDictionary<TPair, double> m, double norm, IEqualityComparer<T> comparer)
    {
      myM = m;
      myComparer = comparer;
      myNorm = norm;
    }
    
    public IEntropyProcessor<T> Divide(ICellCoordinateSystemProjector<T> projector)
    {
      return new EntropyEvaluator<T, NodePair<T>>(
        Project(myM, projector), 
        myNorm, 
        EqualityComparerFactory<T>.GetComparer());
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

      listener.OnResult(v / LN2, values);
    }

    private static void Add<Q>(IDictionary<Q, double> ds, Q node, double v)
    {
      double b;
      if (ds.TryGetValue(node, out b))
        v += b;

      ds[node] = v;
    }
    
    private const double EPS = 1e-10;

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


    private static Dictionary<NodePair<T>, double> Project(IEnumerable<KeyValuePair<TPair, double>> m, ICellCoordinateSystemProjector<T> projector)
    {
      Dictionary<NodePair<T>, double> ret = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

      foreach (KeyValuePair<TPair, double> pair in m)
      {
        T pFrom = projector.Project(pair.Key.From);
        T pTo = projector.Project(pair.Key.To);

        if (pFrom != null && pTo != null)
        {
          Add(ret, new NodePair<T>(pFrom, pTo), pair.Value);
        }
      }
      return ret;
    }    
  }
}