using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.SimpleRunner
{
  public interface IComputeEntropyListener<T>
    where T : ICellCoordinate<T>
  {
    void OnComputeEntropyStarted();
    void OnComputeEntropyFinished(double[] value);

    void OnComputeEntropyStep(double value, IDictionary<T, double> measure, ICellCoordinateSystem<T> system);
  }
}