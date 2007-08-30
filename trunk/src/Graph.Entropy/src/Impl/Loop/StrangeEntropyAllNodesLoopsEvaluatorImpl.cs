using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  internal class StrangeEntropyAllNodesLoopsEvaluatorImpl<T> : EntropyEvaluatorLoopBase<T>
    where T : ICellCoordinate<T>
  {
    public StrangeEntropyAllNodesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {
      return new AllNodesOnALoopGraphSearch<T>(callback, comps, info);
    }
  }
}