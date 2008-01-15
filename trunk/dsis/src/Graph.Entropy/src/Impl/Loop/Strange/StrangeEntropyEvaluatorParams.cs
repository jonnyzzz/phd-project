using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluatorParams
  {
    public readonly StrangeEvaluatorType EntropyType;
    public readonly StrangeEvaluatorStrategy Strategy;
    public readonly IEntropyLoopWeightCallback LoopWeight;

    public StrangeEntropyEvaluatorParams(StrangeEvaluatorType entropyType, StrangeEvaluatorStrategy strategy, IEntropyLoopWeightCallback loopWeight)
    {
      EntropyType = entropyType;
      LoopWeight = loopWeight;
      Strategy = strategy;
    }

    public string PresentableName
    {
      get { return string.Format("{0}:{1}:{2}", EntropyType, Strategy, LoopWeight.Name); }
    }

    private IGraphWeightSearch<Q> CreateSearch<Q>(IGraphStrongComponents<Q> comps, IStrongComponentInfo info)
      where Q : ICellCoordinate
    {
      switch (EntropyType)
      {
        case StrangeEvaluatorType.WeightSearch_1:
          return new GraphWeightSearch<Q>(comps, info);
        case StrangeEvaluatorType.WeightSearch_2:
          return new GraphWeightSearch2<Q>(comps, info);
        case StrangeEvaluatorType.WeightSearch_Filtering:
          return new GraphWeightSearchFiltering<Q>(comps, info);
        case StrangeEvaluatorType.WeightSearch_Limited:
          return new GraphWeightSearchLimited<Q>(comps, info);
        default:
          throw new ArgumentException("Unexpected state " + EntropyType);
      }
    }

    internal ILoopIterator<Q> CreateIterator<Q>(ILoopIteratorCallback<Q> callback, IGraphStrongComponents<Q> comps, IStrongComponentInfo info) 
      where Q : ICellCoordinate
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