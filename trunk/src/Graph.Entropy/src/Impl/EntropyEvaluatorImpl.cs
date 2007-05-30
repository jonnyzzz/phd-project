/*
 * Created by: Eugene Petrenko
 * Created: 21 марта 2007 г.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal abstract class EntropyEvaluatorBase
  {
    public double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
    where T : ICellCoordinate<T>
    {
      EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>();
      foreach (IStrongComponentInfo info in comps.Components)
      {        
        ILoopIterator<T> it = CreateIterator(cb, comps, graph, info, progress);
        it.WidthSearch(progress, info.NodesCount, GetFirst(comps.GetNodes(new IStrongComponentInfo[] { info })));
      }

      return cb.ComputeAntropy(progress);
    }

    protected abstract ILoopIterator<T> CreateIterator<T, C>(
      C callback, IGraphStrongComponents<T> comps, IGraph<T> graph,
      IStrongComponentInfo info, IProgressInfo progress)
      where T : ICellCoordinate<T>
      where C : ILoopIteratorCallback<T>;

    private static T GetFirst<T>(IEnumerable<T> ts) where T : class
    {
      foreach (T t in ts)
      {
        return t;
      }
      return null;
    }
  }

  internal class EntropyEvaluatorImpl : EntropyEvaluatorBase, IEntropyEvaluator
  {
    protected override ILoopIterator<T> CreateIterator<T,C>(C cb, IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                IStrongComponentInfo info, IProgressInfo progress)      
    {
      
        return new LoopIterator<T, NonDuplicatedLoopIteratorCallback<T, C>>(
            new NonDuplicatedLoopIteratorCallback<T, C>(cb), graph, comps, info);
    }
  }

  internal class StrangeEntropyEvaluatorImpl : EntropyEvaluatorBase, IEntropyEvaluator
  {
    protected override ILoopIterator<T> CreateIterator<T, C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new GraphWeightSearch<T, C>(callback, graph, comps, info);
    }
  }
}