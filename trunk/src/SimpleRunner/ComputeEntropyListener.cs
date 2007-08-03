using System;
using System.Collections.Generic;
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
    public override void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                        AbstractImageBuilderContext<Q> cx)
    {
      OnComputeEntropyStarted();

      double[] entropy = EntropyEvaluator.GetLoopEntropyEvaluator().ComputeEntropyWithBackSteps(NullProgressInfo.INSTANCE, graph, comps);

      OnComputeEntropyFinished(TrimRight(entropy)); 
    }

    private static double[] TrimRight(double[] ds)
    {
      int idx;
      for(idx = ds.Length-1; idx >=0; idx--)
      {
        if (Math.Abs(ds[idx]) >= 1e-6)
          break;
      }
      List<double> r = new List<double>();
      for(int i=0; i<idx; i++)
      {
        r.Add(ds[i]);
      }
      return r.ToArray();
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