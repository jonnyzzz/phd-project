using DSIS.Graph.Entropy;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeEigenEntropyListener<T,Q> : ComputeEntropyListenerBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected override string Suffix
    {
      get { return "Eigen"; }
    }

    protected override IEntropyEvaluator<Q> GetLoopEntropyEvaluator()
    {
      return new EigenEntropyEvaluatorImpl<Q>(1e-5);
    }
  }
}