using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Eigen
{
  public class EigenEntropyMeasure<T> : IGraphMeasure<T> 
    where T : ICellCoordinate
  {
    private readonly EigenEntropyEvaluatorImpl<T> myImpl;

    public EigenEntropyMeasure(EigenEntropyEvaluatorImpl<T> impl)
    {
      myImpl = impl;
    }

    public string Method
    {
      get { return "Eigen"; }
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myImpl.Graph.CoordinateSystem; }
    }

    public IEnumerable<Pair<PairBase<T>, double>> Measure
    {
      get { yield break; }
    }

    public IDictionary<T, double> GetMeasureNodes()
    {
      return new Dictionary<T, double>();
    }

    public IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector)
    {
      IGraph<T> graph = myImpl.Graph.Project(projector);
      return new EigenEntropyMeasure<T>(new EigenEntropyEvaluatorImpl<T>(myImpl.Eps, graph));      
    }

    public double GetEntropy()
    {
      return myImpl.ComputeEntropy().GetEntropy();
    }
  }
}