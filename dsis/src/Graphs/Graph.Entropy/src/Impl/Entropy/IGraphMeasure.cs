using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IGraphEntropy
  {
    string Method { get; }
    double GetEntropy();    
  }

  public interface IGraphMeasure
  {
    void DoCallback(IGraphMeasureWith measure);
    double[] CellSize { get; }
  }

  public interface IGraphMeasureWith
  {
    void WithGraphMeasure<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate;
  }

  public interface IGraphMeasure<T> : IGraphEntropy, IGraphMeasure where T : ICellCoordinate
  {
    int EdgesCount { get; }
    int NodesCount { get; }

    ICellCoordinateSystem<T> CoordinateSystem { get;}

    IEnumerable<Pair<PairBase<T>, double>> Measure { get; }

    double ComputeRelativeEntropy(IGraphMeasure<T> initialMeasure);

    IDictionary<T, double> GetMeasureNodes();
    IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector);
  }
}