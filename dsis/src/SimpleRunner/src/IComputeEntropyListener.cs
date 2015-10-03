using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.SimpleRunner
{
  public interface IComputeEntropyListener<T>
    where T : ICellCoordinate
  {
    void OnComputeEntropyStarted();
    void OnComputeEntropyFinished(string key, double[] value);

    void OnComputeEntropyStep<Q>(double value, IDictionary<T, double> measure, IDictionary<Q, double> egdes, ICellCoordinateSystem<T> system) where Q : PairBase<T>; 
  }
}