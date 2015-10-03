using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  [Obsolete]
  public abstract class EntropyEvaluatorLoopBase<T,N> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly IEntropyLoopWeightCallback myLoopCallback;

    protected EntropyEvaluatorLoopBase(IEntropyLoopWeightCallback loopCallback)
    {
      myLoopCallback = loopCallback;
    }


    protected sealed override IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data)
    {
      var cb = new EntropyGraphWeightCallback<T,N>(myLoopCallback, data.Graph.CoordinateSystem);
      foreach (IStrongComponentInfo info in data.Components.Components)
      {
        //TODO: Implement with
        ILoopIterator it = CreateIterator(cb, data.Components, data.Graph, info);
        it.WidthSearch();
      }

      return new EntropyProcessorAdapter<T>(cb.Entropy());
    }

    protected abstract ILoopIterator CreateIterator(ILoopIteratorCallback<T,N> callback,
                                                    IReadonlyGraphStrongComponents<T,N> comps,
                                                    IReadonlyGraph<T,N> graph,
                                                    IStrongComponentInfo info);
  }
}