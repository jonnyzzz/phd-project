using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Combinatorics;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluatorParams
  {
    public StrangeEvaluatorType EntropyType { get; set; }
    public StrangeEvaluatorStrategy Strategy { get; set; }
    public IEntropyLoopWeightCallback LoopWeight { get; set; }

    public StrangeEntropyEvaluatorParams()
    {
      EntropyType = StrangeEvaluatorType.WeightSearch_1;
      Strategy = StrangeEvaluatorStrategy.FIRST;
      LoopWeight = EntropyLoopWeights.CONST;
    }

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
        case StrangeEvaluatorType.Combinatorics:
          return null;
        default:
          throw new ArgumentException("Unexpected state " + EntropyType);
      }
    }

    internal ILoopIterator CreateIterator<Q>(ILoopIteratorCallback<Q> callback, IGraphStrongComponents<Q> comps, IStrongComponentInfo info) 
      where Q : ICellCoordinate
    {
      switch (Strategy)
      {
        case StrangeEvaluatorStrategy.FIRST:
          return new LoopIteratorFirst<Q>(callback, comps, info, CreateSearch(comps, info));
        case StrangeEvaluatorStrategy.SMART:          
          return new LoopIteratorSmart<Q>(callback, comps, info, CreateSearch(comps, info));
        case StrangeEvaluatorStrategy.COMBINATORICS:
          return new CombinatoricsLoopSearch<Q>(callback, comps.AsGraph(new[]{info}), int.MaxValue);
        default:
          throw new ArgumentException("Unexpected state " + Strategy);
      }
    }
  }  
}