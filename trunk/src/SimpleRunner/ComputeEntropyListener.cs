using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeEntropyListener<T,Q> : ProvideExternalListenerBase<T,Q, IComputeEntropyListener>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {

    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      OnComputeEntropyStarted();

      double[] entropy = EntropyEvaluator.GetLoopEntropyEvaluator().ComputeEntropyWithBackSteps(NullProgressInfo.INSTANCE, graph, comps);
      
      OnComputeEntropyFinished(entropy);
    }

    private void OnComputeEntropyFinished(double[] entropy)
    {
      FireListeners(delegate(IComputeEntropyListener listener)
                      {
                        listener.OnComputeEntropyFinished(entropy);
                      });
    }

    private void OnComputeEntropyStarted()
    {
      FireListeners(delegate(IComputeEntropyListener listener)
                      {
                        listener.OnComputeEntropyStarted();
                      });
    }
  }
}