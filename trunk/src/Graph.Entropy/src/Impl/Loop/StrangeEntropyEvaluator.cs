using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public enum StrangeEvaluatorType
  {
    WeightSearch_1,
    WeightSearch_2,
  }

  public enum StrangeEvaluatorStrategy
  {
    FIRST,
    SMART
  }

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

    private IGraphWeightSearch<T> CreateSearch(IGraphStrongComponents<T> comps,
                                               IStrongComponentInfo info)
    {
      switch(myType)
      {
        case StrangeEvaluatorType.WeightSearch_1:
          return new GraphWeightSearch<T>(comps, info);
        case StrangeEvaluatorType.WeightSearch_2:
          return new GraphWeightSearch2<T>(comps, info);
        default:
          throw new ArgumentException("Unexpected state " + myType);
      }
    }

    protected override ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {
      IGraphWeightSearch<T> search = CreateSearch(comps, info);
      switch(myStrategy)
      {
        case StrangeEvaluatorStrategy.FIRST:
          return new LoopIteratorFirst<T>(callback, comps, info, search);
        case StrangeEvaluatorStrategy.SMART:
          return new LoopIteratorSmart<T>(callback, comps, info, search);
        default:
          throw new ArgumentException("Unexpected state " + myStrategy);
      }
    }
  }
}