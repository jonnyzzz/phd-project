using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  [Obsolete]
  internal class StrangeEntropyAllNodesLoopsEvaluatorImpl<T,N> : EntropyEvaluatorLoopBase<T,N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public StrangeEntropyAllNodesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator CreateIterator(ILoopIteratorCallback<T,N> callback,
                                                       IReadonlyGraphStrongComponents<T,N> comps, IReadonlyGraph<T,N> graph,
                                                       IStrongComponentInfo info)
    {
      return new AllNodesOnALoopGraphSearch<T,N>(callback, comps, info);
    }
  }
}