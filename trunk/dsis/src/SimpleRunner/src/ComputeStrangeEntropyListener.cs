using System;
using DSIS.Graph.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeStrangeEntropyListener<T,Q> : ComputeEntropyListenerBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly StrangeEvaluatorType myType;
    private readonly StrangeEvaluatorStrategy myStrategy;
    private readonly IEntropyLoopWeightCallback myCallback;


    public ComputeStrangeEntropyListener(StrangeEvaluatorType type, StrangeEvaluatorStrategy strategy, IEntropyLoopWeightCallback callback)
    {
      myType = type;
      myStrategy = strategy;
      myCallback = callback;
    }

    protected override string Suffix
    {
      get { return string.Format("{0}-{1}-{2}", myType, myStrategy, myCallback.Name); }
    }

    protected override IEntropyEvaluator<Q> GetLoopEntropyEvaluator()
    {
      throw new NotImplementedException();      
    }
  }
}