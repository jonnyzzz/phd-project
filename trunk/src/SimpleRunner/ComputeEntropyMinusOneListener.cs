using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeEntropyMinusOneListener<T,Q> : ComputeEntropyListenerBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override IEntropyEvaluator<Q> GetLoopEntropyEvaluator()
    {
      return EntropyEvaluator<Q>.GetLoopEntropyMunisOneEvaluator();
    }

    protected override string Suffix
    {
      get { return "MinusOne"; }
    }
  }
}