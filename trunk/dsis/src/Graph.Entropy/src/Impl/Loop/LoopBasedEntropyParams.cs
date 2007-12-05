using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Graph.Entropy.Impl.Loop.Strange;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public class LoopBasedEntropyParams
  {
    public readonly StrangeEvaluatorType EntropyType;
    public readonly StrangeEvaluatorStrategy Strategy;

    public LoopBasedEntropyParams(StrangeEvaluatorType entropyType, StrangeEvaluatorStrategy strategy)
    {
      EntropyType = entropyType;
      Strategy = strategy;
    }

    private IGraphWeightSearch<Q> CreateSearch<Q>(IGraphStrongComponents<Q> comps, IStrongComponentInfo info)
      where Q : ICellCoordinate<Q>
    {
      switch (EntropyType)
      {
        case StrangeEvaluatorType.WeightSearch_1:
          return new GraphWeightSearch<Q>(comps, info);
        case StrangeEvaluatorType.WeightSearch_2:
          return new GraphWeightSearch2<Q>(comps, info);
        default:
          throw new ArgumentException("Unexpected state " + EntropyType);
      }

    }

    internal ILoopIterator<Q> CreateIterator<Q>(ILoopIteratorCallback<Q> callback, IGraphStrongComponents<Q> comps, IStrongComponentInfo info) where Q : ICellCoordinate<Q>
    {
      IGraphWeightSearch<Q> search = CreateSearch(comps, info);
      switch (Strategy)
      {
        case StrangeEvaluatorStrategy.FIRST:
          return new LoopIteratorFirst<Q>(callback, comps, info, search);
        case StrangeEvaluatorStrategy.SMART:
          return new LoopIteratorSmart<Q>(callback, comps, info, search);
        default:
          throw new ArgumentException("Unexpected state " + Strategy);
      }
    }
  }
}