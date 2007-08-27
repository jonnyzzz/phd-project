using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal class StrangeEntropyEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    public StrangeEntropyEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }

    protected override ILoopIterator<T> CreateIterator<C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new GraphWeightSearch<T>(callback, comps, info);
    }
  }

  internal class StrangeEntropyAllEdgesLoopsEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    public StrangeEntropyAllEdgesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }

    protected override ILoopIterator<T> CreateIterator<C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new AllEngesOnALoopGraphSearch<T>(callback, comps, info);
    }
  }
  
  internal class StrangeEntropyAllNodesLoopsEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    public StrangeEntropyAllNodesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }

    protected override ILoopIterator<T> CreateIterator<C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new AllNodesOnALoopGraphSearch<T>(callback, comps, info);
    }
  }
}