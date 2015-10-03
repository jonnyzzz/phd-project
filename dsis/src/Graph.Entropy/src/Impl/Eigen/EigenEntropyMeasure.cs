using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
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

    public int EdgesCount
    {
      get { return myImpl.Graph.EdgesCount; }
    }

    public int NodesCount
    {
      get { return myImpl.Graph.NodesCount; }
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
      return ProjectInternal(projector);
    }

    public EigenEntropyMeasure<T> ProjectInternal(ICellCoordinateSystemProjector<T> projector)
    {
      var graph = myImpl.Graph.Project(projector);
      return new EigenEntropyMeasure<T>(new EigenEntropyEvaluatorImpl<T>(myImpl.Eps, graph));      
    }

    public double GetEntropy()
    {
      return myImpl.ComputeEntropy().GetEntropy();
    }

    public void DoCallback(IGraphMeasureWith measure)
    {
      measure.WithGraphMeasure(this);
    }

    public double[] CellSize
    {
      get { return ((IIntegerCoordinateSystem) myImpl.Graph.CoordinateSystem).CellSize; }
    }
  }
}