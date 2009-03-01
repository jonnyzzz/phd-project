using System;
using System.Globalization;
using System.Threading;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class ThesisEntropyBuildBase<T> : SIBuild<T>
    where T : EntropyComputationData
  {
    protected override IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction, IAction system, IAction workingFolder, IAction logger, T sys, bool isLast)
    {
      if (isLast)
      {
        foreach (var mode in sys.EntropyMode)
        {
          Func<Pair<IAction, string>> func = GetEntropeMode(mode);
          BuildJVRCall(siConstructionAction, system, func);          
        }
      }
      return base.CreateActionsAfterSI(siConstructionAction, system, workingFolder, logger, sys, isLast);
    }

    private static Func<Pair<IAction, string>> GetEntropeMode(EntropyComputationMode mode)
    {
      switch(mode)
      {
        case EntropyComputationMode.Eigen:
          return () =>
                   {
                     var options = new EigenEntropyOptions();
                     return Pair.Of<IAction, string>(new EigenEntropyAction(options), options.Present);
                   };
        case EntropyComputationMode.JVR:
          return () => CreateMeasureAction(1e-5);
        case EntropyComputationMode.SmartLoops:
          return () =>
                   {
                     var opts = new StrangeEntropyEvaluatorParams
                                  {
                                    EntropyType = StrangeEvaluatorType.WeightSearch_1,
                                    LoopWeight = EntropyLoopWeights.CONST,
                                    Strategy = StrangeEvaluatorStrategy.SMART
                                  };
                     return Pair.Of<IAction, string>(new StrangeEntropyAction(), opts.Present);
                   };
        case EntropyComputationMode.Loops:
          return () =>
                   {
                     var opts = new StrangeEntropyEvaluatorParams
                                  {
                                    EntropyType = StrangeEvaluatorType.WeightSearch_1,
                                    LoopWeight = EntropyLoopWeights.CONST,
                                    Strategy = StrangeEvaluatorStrategy.FIRST
                                  };
                     return Pair.Of<IAction, string>(new StrangeEntropyAction(), opts.Present);
                   };
        default:
          throw new NotImplementedException("Entropy mode " + mode + " is not supported");
      }
    }

    private static void BuildJVRCall(IActionEdgesBuilder siConstructionAction, IAction system, Func<Pair<IAction,string>> factory)
    {
      var result = factory();
      var key = new RecordTimeAction(result.First, "XxX" + result.Second);
      siConstructionAction
        .Edge(key)
        .Edge(new DumpJVR(result.Second, key.Key))
        .With(x => x.Back(siConstructionAction))
        .With(x => x.Back(system))
        .With(x => x.Back(new GCAction()))
        ;
    }

    private static Pair<IAction, string> CreateMeasureAction(double eps)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false, 
                     InitialWeight = EntropyLoopWeights.CONST, 
                     EPS = eps, 
                     ExitCondition = JVRExitCondition.SummError
                   };
      IAction action = new JVRMeasureAction(opts);
      var present = opts.Present;
      return Pair.Of(action, present);
    }

    private class DumpJVR : IntegerCoordinateSystemActionBase3
    {
      private readonly string myOpts;
      private readonly Key<TimeSpan> myTime;

      public DumpJVR(string opts, Key<TimeSpan> time)
      {
        myOpts = opts;
        myTime = time;
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        var log = Logger.Instance(input);
        var ctx = Keys.GraphMeasure<Q>().Get(input);
        var time = myTime.Get(input).TotalMilliseconds;

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

        log.Write("Construct JVR measure using: " + myOpts);
        log.Write(string.Format("Construct JVR measure time: {0}ms", time));
        log.Write(string.Format("Construct JVR measure entropy: {0}", ctx.GetEntropy()));
      }
    }
  }
}