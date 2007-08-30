using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  internal class StrangeEntropyEvaluatorImpl<T> : EntropyEvaluatorLoopBase<T>
    where T : ICellCoordinate<T>
  {
    public StrangeEntropyEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {
      return new GraphWeightSearch<T>(callback, comps, info);
    }
  }
}