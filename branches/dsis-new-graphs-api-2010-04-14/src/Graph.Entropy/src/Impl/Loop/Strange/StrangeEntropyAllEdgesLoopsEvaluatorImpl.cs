using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  [Obsolete]
  internal class StrangeEntropyAllEdgesLoopsEvaluatorImpl<T, N> : EntropyEvaluatorLoopBase<T, N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public StrangeEntropyAllEdgesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator CreateIterator(ILoopIteratorCallback<T,N> callback,
                                                       IReadonlyGraphStrongComponents<T,N> comps, 
      IReadonlyGraph<T,N> graph,
                                                       IStrongComponentInfo info)
    {
      return new AllEngesOnALoopGraphSearch<T,N>(callback, comps, info);
    }
  }
}