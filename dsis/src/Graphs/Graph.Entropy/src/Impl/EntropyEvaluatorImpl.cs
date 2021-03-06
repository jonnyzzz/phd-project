/*
 * Created by: Eugene Petrenko
 * Created: 21 ����� 2007 �.
 */

using System;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl
{
  [Obsolete]
  internal class EntropyEvaluatorImpl<T> : EntropyEvaluatorLoopBase<T>
    where T : ICellCoordinate
  {
    public EntropyEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {      
        return new LoopIteratorFirst<T>(
            new NonDuplicatedLoopIteratorCallback<T, ILoopIteratorCallback<T>>(callback), comps, info,
            new LoopIterator<T>(graph, comps, info));
    }
  }
}