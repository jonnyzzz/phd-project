/*
 * Created by: Eugene Petrenko
 * Created: 21 марта 2007 г.
 */

using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl
{
  [Obsolete]
  internal class EntropyEvaluatorImpl<T, N> : EntropyEvaluatorLoopBase<T,N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    public EntropyEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator CreateIterator(ILoopIteratorCallback<T, N> callback,
                                                       IReadonlyGraphStrongComponents<T, N> comps,
      IReadonlyGraph<T, N> graph,
                                                       IStrongComponentInfo info)
    {
      return new LoopIteratorFirst<T, N>(
        new NonDuplicatedLoopIteratorCallback<T, N, ILoopIteratorCallback<T, N>>(callback), comps, info,
        new LoopIterator<T, N>(comps, info));
    }
  }
}