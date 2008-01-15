using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IGraphEntropy
  {
    double GetEntropy();    
  }

  public interface IGraphMeasure<T> : IGraphEntropy where T : ICellCoordinate
  {
    IEnumerable<Pair<PairBase<T>, double>> Measure { get; }    
    IDictionary<T, double> GetMeasureNodes();
    IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector);
  }
}