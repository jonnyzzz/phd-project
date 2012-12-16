using System;
using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.SimpleRunner.Builder;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
{
  public abstract class ThesisJVREntropyBuildBase :
    ThesisEntropyBuildBase<EntropyComputationData<object>, object>
  {
    protected override IEnumerable<object> GetEntropComputationMode(
      AfterSIParams<EntropyComputationData<object>> afterSIParams)
    {
      yield return new object();
    }

    protected override void RemoveActionFrom(List<EntropyComputationData<object>> actions, EntropyComputationData<object> computationData, object mode)
    {
      //NOP.
    }

    protected override Func<Pair<IAction, string>> GetEntropyAction(object mode)
    {
      return () => CreateJVRMeasureAction(1e-05);
    }

    private static Pair<IAction, string> CreateJVRMeasureAction(double eps)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false,
                     InitialWeight = EntropyEdgeWeights.CONST,
                     EPS = eps,
                     ExitCondition = JVRExitCondition.EdgesChangeError //FAKE!
                   };
      return Pair.Of((IAction) new LoggingJVRMeasureAction(opts), opts.Present);
    }

    private class LoggingJVRMeasureAction : JVRMeasureAction
    {
      public LoggingJVRMeasureAction(JVRMeasureOptions opts) : base(opts)
      {
      }

      protected override JVREvaluator<Q> CreateEvaluator<Q>(JVRMeasureOptions opts, Context ctx)
      {
        return new LoggingJVREvaluator<Q>(opts, Logger.Instance(ctx));
      }
    }

  }
}