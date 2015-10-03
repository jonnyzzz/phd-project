using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Combinatorics;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluatorParams : IOptionsValueChecker
  {
    [IncludeGenerate(Title = "Method type")]
    public StrangeEvaluatorType EntropyType { get; set; }
    [IncludeGenerate(Title = "Strategy")]
    public StrangeEvaluatorStrategy Strategy { get; set; }
    [IncludeGenerate(Title = "Loop weight"), IncludeValuesProvider(typeof(EntropyLoopWeights))]
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
      get { return Present; }
    }

    public string Present
    {
      get { return string.Format("LoopEntropy[type={0},stategy={1},width={2}", EntropyType, Strategy, LoopWeight.Name); }
    }

    private IGraphWeightSearch<Q,N> CreateSearch<Q,N>(IReadonlyGraphStrongComponents<Q,N> comps, IStrongComponentInfo info)
      where Q : ICellCoordinate
      where N : class, INode<Q>
    {
      switch (EntropyType)
      {
        case StrangeEvaluatorType.WeightSearch_1:
          return new GraphWeightSearch<Q,N>(comps, info);
        case StrangeEvaluatorType.WeightSearch_2:
          return new GraphWeightSearch2<Q,N>(comps, info);
        case StrangeEvaluatorType.WeightSearch_Filtering:
          return new GraphWeightSearchFiltering<Q,N>(comps, info);
        case StrangeEvaluatorType.WeightSearch_Limited:
          return new GraphWeightSearchLimited<Q,N>(comps, info);
        case StrangeEvaluatorType.Combinatorics:
          return null;
        default:
          throw new ArgumentException("Unexpected state " + EntropyType);
      }
    }

    internal ILoopIterator CreateIterator<Q,N>(ILoopIteratorCallback<Q,N> callback, IReadonlyGraphStrongComponents<Q,N> comps, IStrongComponentInfo info) 
      where Q : ICellCoordinate
      where N : class, INode<Q>
    {
      switch (Strategy)
      {
        case StrangeEvaluatorStrategy.FIRST:
          return new LoopIteratorFirst<Q,N>(callback, comps, info, CreateSearch(comps, info));
        case StrangeEvaluatorStrategy.SMART:          
          return new LoopIteratorSmart<Q,N>(callback, comps, info, CreateSearch(comps, info));
        case StrangeEvaluatorStrategy.COMBINATORICS:
          return new CombinatoricsLoopSearch<Q,N>(callback, comps.Accessor(info.Enum()).AsGraph(), int.MaxValue);
        default:
          throw new ArgumentException("Unexpected state " + Strategy);
      }
    }

    public void HasErrors(string fieldName, Action<string> setError)
    {
      if (fieldName == "EntropyType" || fieldName == "Strategy")
      {
        if (EntropyType == StrangeEvaluatorType.Combinatorics ^ Strategy == StrangeEvaluatorStrategy.COMBINATORICS)
        {
          setError("Combinatorics is only compatible with combinatorics");
        }
      }
    }
  }  
}