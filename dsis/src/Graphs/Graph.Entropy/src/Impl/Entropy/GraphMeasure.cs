using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class GraphMeasure<T, TPair> : IGraphMeasure<T>
    where TPair : PairBase<T>
    where T : ICellCoordinate
  {
    private const double EPS = 1e-10;

    private readonly IEqualityComparer<T> myComparer;
    private readonly ICellCoordinateSystem<T> myCoorsinateSystem;
    private readonly IDictionary<TPair, double> myM;
    private readonly string myMethodName;

    private readonly double myNorm;
    private double? myEntropy;
    private Dictionary<T, double> myNodesM;

    public GraphMeasure(string name, IDictionary<TPair, double> m,
                        IEqualityComparer<T> comparer, double norm,
                        ICellCoordinateSystem<T> coorsinateSystem)
    {
      myMethodName = name;
      myCoorsinateSystem = coorsinateSystem;
      myM = m;
      myComparer = comparer;
      myNorm = norm;
    }

    public double Norm
    {
      get { return myNorm; }
    }

    public IDictionary<TPair, double> M
    {
      get { return myM; }
    }

    #region IGraphMeasure<T> Members

    public string Method
    {
      get { return myMethodName; }
    }

    public int EdgesCount
    {
      get { return myM.Count; }
    }

    public int NodesCount
    {
      get { return myNodesM.Count; }
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myCoorsinateSystem; }
    }

    public IEnumerable<Pair<PairBase<T>, double>> Measure
    {
      //todo: yield
      get {
        return myM.Select(pair => Pair.Of((PairBase<T>) pair.Key, pair.Value/myNorm));
      }
    }

    public IDictionary<T, double> GetMeasureNodes()
    {
      if (myNodesM == null)
        ComputeEntropy();

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
        GraphMeasure<T, NodePair<T>>(Method,
                                     Project(myM, projector),
                                     EqualityComparerFactory<T>.GetComparer(),
                                     myNorm, projector.ToSystem);
    }

    public void DoCallback(IGraphMeasureWith measure)
    {
      measure.WithGraphMeasure(this);
    }

    public double[] CellSize
    {
      get { return ((IIntegerCoordinateSystem) myCoorsinateSystem).CellSize; }
    }

    #endregion

    private static Dictionary<NodePair<T>, double> Project(IEnumerable<KeyValuePair<TPair, double>> m,
                                                           ICellCoordinateSystemProjector<T> projector)
    {
      var ret = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());
      ICellCoordinateSystem<T> toSystem = projector.ToSystem;

      foreach (var pair in m)
      {
        T pFrom = projector.Project(pair.Key.From);
        T pTo = projector.Project(pair.Key.To);

        if (toSystem.IsNull(pTo))
          continue;
        if (toSystem.IsNull(pFrom))
          continue;

        Add(ret, new NodePair<T>(pFrom, pTo), pair.Value);
      }
      return ret;
    }

    private void ComputeEntropy()
    {
      double v = 0;
      var values = new Dictionary<T, double>(myComparer);

      foreach (var pair in myM)
      {
        double val = pair.Value/myNorm;
        Add(values, pair.Key.To, val);
        v -= Entropy(val);
      }

      v += values.Values.Sum(value => Entropy(value));

      myEntropy = v;
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
      return Math.Log(d, 2);
    }

    private static double Entropy(double d)
    {
      if (d < EPS)
        return 0;

      return d*Log(d);
    }

    private static double Entropy(double i, double d)
    {
      if (d < EPS)
        return 0;

      return d*Log(i / d);
    }

    private double GetEdgeValue(TPair p)
    {
      double d;
      return myM.TryGetValue(p, out d) ? d : 0;
    }

    public double ComputeRelativeEntropy(IGraphMeasure<T> initialMeasure)
    {
      if (!Equals(initialMeasure.CoordinateSystem, CoordinateSystem))
        throw new Exception("Different coordinate systems");

      double v = 0;
      foreach (var p in initialMeasure.Measure)
      {
        var arc = (TPair) p.First;
        var oldValue = p.Second;
        var newValue = GetEdgeValue(arc);

        v += Entropy(oldValue, newValue);
      }

      return -v;
    }
  }
}