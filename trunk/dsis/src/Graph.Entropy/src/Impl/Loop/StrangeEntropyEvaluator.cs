using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class StrangeEntropyEvaluator<T> : EntropyEvaluatorLoopBase<T> 
    where T : ICellCoordinate<T>
  {
    private readonly StrangeEvaluatorType myType;
    private readonly StrangeEvaluatorStrategy myStrategy;


    public StrangeEntropyEvaluator(IEntropyLoopWeightCallback loopCallback, StrangeEvaluatorType type, StrangeEvaluatorStrategy strategy) : base(loopCallback)
    {
      myType = type;
      myStrategy = strategy;
    }

    protected override ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {
      return new LoopBasedEntropyParams(myType, myStrategy).CreateIterator(callback, comps, info);
    }
  }
}