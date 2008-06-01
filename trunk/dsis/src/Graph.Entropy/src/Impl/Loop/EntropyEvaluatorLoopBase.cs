using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete]
  public abstract class EntropyEvaluatorLoopBase<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate
  {
    private readonly IEntropyLoopWeightCallback myLoopCallback;

    protected EntropyEvaluatorLoopBase(IEntropyLoopWeightCallback loopCallback)
    {
      myLoopCallback = loopCallback;
    }


    protected sealed override IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data)
    {
      EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>(myLoopCallback, data.Graph.CoordinateSystem);
      foreach (IStrongComponentInfo info in data.Components.Components)
      {
        ILoopIterator it = CreateIterator(cb, data.Components, data.Graph, info);
        it.WidthSearch();
      }

      return new EntropyProcessorAdapter<T>(cb.Entropy());
    }

    protected abstract ILoopIterator CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info);
  }
}