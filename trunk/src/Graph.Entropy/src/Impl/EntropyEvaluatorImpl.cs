/*
 * Created by: Eugene Petrenko
 * Created: 21 марта 2007 г.
 */

using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal class EntropyEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    public EntropyEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }

    protected override ILoopIterator<T> CreateIterator<C>(C cb, IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                IStrongComponentInfo info, IProgressInfo progress)      
    {
      
        return new LoopIterator<T>(
            new NonDuplicatedLoopIteratorCallback<T, C>(cb), graph, comps, info);
    }
  }
}