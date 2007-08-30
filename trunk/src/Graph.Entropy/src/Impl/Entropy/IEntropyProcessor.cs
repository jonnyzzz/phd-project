using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IEntropyProcessor<T>
    where T : ICellCoordinate<T>
  {
    void ComputeEntropy(IEntropyListener<T> listener);

    IEntropyProcessor<T> Divide(ICellCoordinateSystemProjector<T> projector);
  }
}