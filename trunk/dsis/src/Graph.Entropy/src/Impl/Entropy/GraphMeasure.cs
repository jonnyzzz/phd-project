using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class GraphMeasure<T, TPair> : IGraphMeasure<T>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>
  {
    private const double EPS = 1e-10;
    private static readonly double LN2 = Math.Log(2);

    private readonly IEqualityComparer<T> myComparer;
    private readonly IDictionary<TPair, double> myM;

    private readonly double myNorm;
    private double? myEntropy;
    private Dictionary<T, double> myNodesM = null;

    public GraphMeasure(IDictionary<TPair, double> m, IEqualityComparer<T> comparer, double norm)
    {
      myM = m;
      myComparer = comparer;
      myNorm = norm;
    }

    #region IGraphMeasure<T> Members

    public IEnumerable<Pair<PairBase<T>, double>> Measure
    {
      //todo: yield
      get
      {
        foreach (KeyValuePair<TPair, double> pair in myM)
        {
          yield return Pair.Create((PairBase<T>) pair.Key, pair.Value);
        }
      }
    }

    public IDictionary<T, double> GetMeasureNodes()
    {
      if (myNodesM == null)
      {
        ComputeEntropy();
      }
      return myNodesM;
    }

    public double GetEntropy()
    {
      if (myEntropy == null)
      {
        ComputeEntropy();
      }
      return myEntropy.Value;
    }

    public IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector)
    {
      return new
        GraphMeasure<T, NodePair<T>>(
        Project(myM, projector),
        EqualityComparerFactory<T>.GetComparer(),
        myNorm);
    }

    #endregion

    private static Dictionary<NodePair<T>, double> Project(IEnumerable<KeyValuePair<TPair, double>> m,
                                                           ICellCoordinateSystemProjector<T> projector)
    {
      Dictionary<NodePair<T>, double> ret =
        new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

      foreach (KeyValuePair<TPair, double> pair in m)
      {
        T pFrom = projector.Project(pair.Key.From);
        T pTo = projector.Project(pair.Key.To);

        if (Equals(pFrom, null) && Equals(pTo, null))
        {
          Add(ret, new NodePair<T>(pFrom, pTo), pair.Value);
        }
      }
      return ret;
    }

    private void ComputeEntropy()
    {
      double v = 0;
      Dictionary<T, double> values = new Dictionary<T, double>(myComparer);

      foreach (KeyValuePair<TPair, double> pair in myM)
      {
        double val = pair.Value/myNorm;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
      }

      foreach (double value in values.Values)
      {
        v += Entropy(value);
      }

      myEntropy = v/LN2;
      myNodesM = values;
    }

    private static void Add<Q>(IDictionary<Q, double> ds, Q node, double v)
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

      return d*Log(d);
    }
  }
}