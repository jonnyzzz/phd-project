using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IGraphMeasure<T> where T : ICellCoordinate<T>
  {
    double Norm { get; }
    IEqualityComparer<T> Comparer { get; }
    IEnumerable<Pair<PairBase<T>, double>> Measure { get; }
    
    IDictionary<T, double> GetMeasureNodes();
    double GetEntropy();

    IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector);
  }
}