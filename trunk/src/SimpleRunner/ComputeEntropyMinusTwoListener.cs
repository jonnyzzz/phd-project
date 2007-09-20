using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeEntropyMinusTwoListener<T,Q> : ComputeEntropyListenerBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override IEntropyEvaluator<Q> GetLoopEntropyEvaluator()
    {
      return EntropyEvaluator<Q>.GetLoopEntropyMunisTwoEvaluator();
    }

    protected override string Suffix
    {
      get { return "MinusTwo"; }
    }
  }
}