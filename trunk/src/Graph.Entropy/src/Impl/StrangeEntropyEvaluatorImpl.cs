using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
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