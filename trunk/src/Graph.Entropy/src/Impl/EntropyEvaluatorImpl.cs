/*
 * Created by: Eugene Petrenko
 * Created: 21 ����� 2007 �.
 */

using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal class EntropyEvaluatorImpl : EntropyEvaluatorBase, IEntropyEvaluator
  {
    protected override ILoopIterator<T> CreateIterator<T,C>(C cb, IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                IStrongComponentInfo info, IProgressInfo progress)      
    {
      
        return new LoopIterator<T, NonDuplicatedLoopIteratorCallback<T, C>>(
            new NonDuplicatedLoopIteratorCallback<T, C>(cb), graph, comps, info);
    }
  }
}