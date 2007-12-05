using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class EntropyProcessorAdapter<T> : IEntropyProcessor<T> 
    where T : ICellCoordinate<T>
  {
    private readonly IGraphMeasure<T> myMeasure;

    public EntropyProcessorAdapter(IGraphMeasure<T> measure)
    {
      myMeasure = measure;
    }

    public void ComputeEntropy(IEntropyListener<T> listener)
    {
      listener.OnResult<PairBase<T>>(myMeasure.GetEntropy(), myMeasure.GetMeasureNodes(), null);
    }

    public IEntropyProcessor<T> Divide(ICellCoordinateSystemProjector<T> projector)
    {
      return new EntropyProcessorAdapter<T>(myMeasure.Project(projector));
    }
  }
}