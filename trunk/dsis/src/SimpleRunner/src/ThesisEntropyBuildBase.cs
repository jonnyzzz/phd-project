using System;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
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
    where T : EntropyComputationData, ICloneable<T>
  {
    protected override IAction GetLastStepImage()
    {
      return new EntropyPointMethodSettings();
    }

    protected override IActionEdgesBuilder CreateActionsAfterSI(AfterSIParams<T> afterSIParams)
    {
      if (afterSIParams.IsLast)
      {
        foreach (var mode in afterSIParams.ComputationData.EntropyMode)
        {
          BuildJVRCall(afterSIParams, GetEntropeMode(mode));          
        }
      }
      return base.CreateActionsAfterSI(afterSIParams);
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

        case EntropyComputationMode.SmartLoopsConst:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.CONST);

        case EntropyComputationMode.SmartLoopsLinear:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.ONE);

        case EntropyComputationMode.SmartLoopsSquare:
          return () => CreateStrangeEntropySmart(EntropyLoopWeights.TWO);

        case EntropyComputationMode.LoopsConst:
          return () =>
                   {
                     var opts = new StrangeEntropyEvaluatorParams
                                  {
                                    EntropyType = StrangeEvaluatorType.WeightSearch_1,
                                    LoopWeight = EntropyLoopWeights.CONST,
                                    Strategy = StrangeEvaluatorStrategy.FIRST
                                  };
                     return Pair.Of<IAction, string>(new ParametrizedStrangeEntropyAction(opts), opts.Present);
                   };
        default:
          throw new NotImplementedException("Entropy mode " + mode + " is not supported");
      }
    }

    private static Pair<IAction, string> CreateStrangeEntropySmart(IEntropyLoopWeightCallback @const)
    {
      var opts = new StrangeEntropyEvaluatorParams
                   {
                     EntropyType = StrangeEvaluatorType.WeightSearch_Limited,
                     LoopWeight = @const,
                     Strategy = StrangeEvaluatorStrategy.SMART
                   };
      return Pair.Of<IAction, string>(new ParametrizedStrangeEntropyAction(opts), opts.Present);
    }

    private static void BuildJVRCall(AfterSIParams<T> afterSIParams, Func<Pair<IAction, string>> factory)
    {
      var result = factory();
      var bs = afterSIParams.SiConstructionAction.Edge(new FilterProxyAction(FileKeys.WorkingFolderKey));

      var id = new RecordTimeAction(result.First, "XxX" + result.Second);
      var key = bs.Edge(id);

      var wf = bs.Back(new SetEntropyMethodWorkingFolderPrefix(result.Second));
      wf.Back(afterSIParams.WorkingFolder);

      key.Back(afterSIParams.System);

      var loggerEx = key.Back(new LoggerAction()).WithBack(wf);

      key.Edge(new DumpJVR(result.Second, id.Key))
        .WithBack(loggerEx)
        .Back(new SelectiveCopyAction(Keys.IntegerCoordinateSystemInfo))
        .Back(afterSIParams.SiConstructionAction);

      key.Edge(new DrawEntropyMeasureWithBaseAction())
        .WithBack(wf)
        .WithBack(afterSIParams.System)
        .Back(new SelectiveCopyAction(Keys.IntegerCoordinateSystemInfo)).Back(afterSIParams.SiConstructionAction)
        ;
    }

    private static Pair<IAction, string> CreateMeasureAction(double eps)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false, 
                     InitialWeight = EntropyLoopWeights.CONST, 
                     EPS = eps, 
                     ExitCondition = JVRExitCondition.MaxRelativeNodeError
                   };
      return Pair.Of((IAction) new JVRMeasureAction(opts), opts.Present);
    }

    private class SetEntropyMethodWorkingFolderPrefix : PrefixWorkingFolderAction
    {
      private readonly string myEntropyMethodString;

      public SetEntropyMethodWorkingFolderPrefix(string entropyMethodString)
      {
        myEntropyMethodString = entropyMethodString;
      }

      protected override string Prefix(Context ctx)
      {
        return myEntropyMethodString;
      }
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

      protected override void Apply<_, Q>(Context input, Context output)
      {
        var log = Logger.Instance(input);
        var ctx = Keys.GraphMeasure<Q>().Get(input);
        var time = myTime.Get(input).TotalMilliseconds;

        log.Write("Construct measure using: " + myOpts);
        log.Write(string.Format("measure time: {0}ms", time));
        log.Write(string.Format("measure entropy: {0}", ctx.GetEntropy()));
      }
    }
  }
}