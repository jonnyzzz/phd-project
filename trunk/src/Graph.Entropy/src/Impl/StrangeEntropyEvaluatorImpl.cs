using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal class StrangeEntropyEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    protected override ILoopIterator<T> CreateIterator<C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new GraphWeightSearch<T>(callback, graph, comps, info);
    }
  }

  internal class StrangeEntropyAllLoopsEvaluatorImpl<T> : EntropyEvaluatorBase<T>
    where T : ICellCoordinate<T>
  {
    protected override ILoopIterator<T> CreateIterator<C>(C callback, IGraphStrongComponents<T> comps,
                                                             IGraph<T> graph, IStrongComponentInfo info,
                                                             IProgressInfo progress)
    {
      return new AllEngesOnALoopGraphSearch<T>(callback, comps, info);
    }
  }
}