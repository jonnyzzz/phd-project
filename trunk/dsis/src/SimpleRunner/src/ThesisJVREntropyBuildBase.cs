using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class ThesisJVREntropyBuildBase :
    ThesisEntropyBuildBase<EntropyComputationData<JVRExitCondition>, JVRExitCondition>
  {
    protected override IEnumerable<JVRExitCondition> GetEntropComputationMode(
      AfterSIParams<EntropyComputationData<JVRExitCondition>> afterSIParams)
    {
      return afterSIParams.ComputationData.EntropyMode;
    }

    protected override Func<Pair<IAction, string>> GetEntropyAction(JVRExitCondition mode)
    {
      return () => CreateJVRMeasureAction(1e-05, mode);
    }

    private static Pair<IAction, string> CreateJVRMeasureAction(double eps, JVRExitCondition mode)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false,
                     InitialWeight = EntropyLoopWeights.CONST,
                     EPS = eps,
                     ExitCondition = mode
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
        return new JVREvaluatorEx<Q>(opts, Logger.Instance(ctx));
      }
    }

    private class JVREvaluatorEx<Q> : JVREvaluator<Q>
      where Q : ICellCoordinate
    {
      private readonly Logger myLogger;

      public JVREvaluatorEx(JVRMeasureOptions opts, Logger logger) : base(opts)
      {
        myLogger = logger;
      }

      protected override JVRMeasure<Q> CreateMeasure(IGraph<Q> graph, IGraphStrongComponents<Q> comps)
      {
        return new LoggingEvaluator<Q>(graph, comps, myOpts, myLogger);
      }
    }

    private class LoggingEvaluator<Q> : JVRMeasure<Q>
      where Q : ICellCoordinate
    {
      private readonly Logger myLog;
      private int stepCount;

      public LoggingEvaluator(IGraph<Q> graph, IGraphStrongComponents<Q> components, JVRMeasureOptions opts, Logger log)
        : base(graph, components, opts)
      {
        myLog = log;
      }

      protected override bool CheckExitCondition(double precision, double totalError, double qValue, double nodesChange,
                                                 double edgesChange)
      {
        myLog.Write("-->{5} precision:{0}, totalError:{1}, q:{2}, nodesChange:{3}, edgesChange:{4}",
                    precision, totalError, qValue, nodesChange, edgesChange, ++stepCount);
        return base.CheckExitCondition(precision, totalError, qValue, nodesChange, edgesChange);
      }
    }
  }
}