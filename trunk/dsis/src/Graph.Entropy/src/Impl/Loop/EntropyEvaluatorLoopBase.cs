using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public abstract class EntropyEvaluatorLoopBase<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    private readonly IEntropyLoopWeightCallback myLoopCallback;

    protected EntropyEvaluatorLoopBase(IEntropyLoopWeightCallback loopCallback)
    {
      myLoopCallback = loopCallback;
    }


    protected sealed override IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data)
    {
      EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>(myLoopCallback);
      foreach (IStrongComponentInfo info in data.Components.Components)
      {
        ILoopIterator<T> it = CreateIterator(cb, data.Components, data.Graph, info);
        it.WidthSearch();
      }

      return new EntropyProcessorAdapter<T>(cb.Entropy());
    }

    protected abstract ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info);
  }
}