using System;
using System.Collections.Generic;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.SimpleRunner.Builder;
using DSIS.SimpleRunner.Computation;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
{
  public abstract class ThesisEntropyBuildBase<T, Q> : SIBuild<T>
    where T : ComputationData, ICloneable<T>
  {
    protected abstract IEnumerable<Q> GetEntropComputationMode(AfterSIParams<T> afterSIParams);
    protected abstract Func<Pair<IAction, string>> GetEntropyAction(Q mode);
    protected abstract void RemoveActionFrom(List<T> actions, T computationData, Q mode);

    protected sealed override IAction GetLastStepImage()
    {
      return new EntropyPointMethodSettings();
    }

    protected override IActionEdgesBuilder CreateActionsAfterSI(AfterSIParams<T> afterSIParams)
    {
      if (afterSIParams.IsLast)
      {
        foreach (var mode in GetEntropComputationMode(afterSIParams))
        {
          BuildJVRCall(afterSIParams, GetEntropyAction(mode), mode);
        }
      }
      return base.CreateActionsAfterSI(afterSIParams);
    }

    private readonly MultiDictionary<T, Q> myPendingActions = new MultiDictionary<T, Q>(EqualityComparerFactory<T>.GetComparer());
    private readonly MultiDictionary<T, Q> myFinishedActions = new MultiDictionary<T, Q>(EqualityComparerFactory<T>.GetComparer());

    private void ActionStarted(T computationData, Q mode)
    {
      myPendingActions.AddValue(computationData, mode);
    }

    private void ActionFinished(T computationData, Q mode)
    {
      myPendingActions.RemoveWhere(computationData, x=>Equals(x, mode));
      myFinishedActions.AddValue(computationData, mode);
    }

    protected override void OnComputationInterrupt(List<T> actions, T action)
    {
      var set = new HashSet<Q>();
      set.UnionWith(myPendingActions.GetValues(action));
      set.IntersectWith(myFinishedActions.GetValues(action));

      foreach (var q in set)
      {
        RemoveActionFrom(actions, action, q);
      }
    }

    private void BuildJVRCall(AfterSIParams<T> afterSIParams, Func<Pair<IAction, string>> factory, Q mode)
    {
      var result = factory();
      var bs = afterSIParams.SiConstructionAction.Edge(new FilterProxyAction(FileKeys.WorkingFolderKey));

      var id = new RecordTimeAction(new ReportAction(result.First, this, afterSIParams.ComputationData, mode), "XxX" + result.Second);
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

    private class ReportAction : IAction 
    {
      private readonly T myComputationData;
      private readonly Q myMode;
      private readonly IAction myHost;
      private readonly ThesisEntropyBuildBase<T, Q> myHolder;

      public ReportAction(IAction host, ThesisEntropyBuildBase<T, Q> holder, T computationData, Q mode)
      {
        myHost = host;
        myMode = mode;
        myComputationData = computationData;
        myHolder = holder;
      }

      public ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return myHost.Compatible(ctx);
      }

      public Context Apply(Context ctx)
      {
        myHolder.ActionStarted(myComputationData, myMode);
        try
        {
          return myHost.Apply(ctx);
        } finally
        {
          myHolder.ActionFinished(myComputationData, myMode);
        }
      }

      public IAction Clone()
      {
        return new ReportAction(myHost.Clone(), myHolder, myComputationData, myMode);
      }
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

    private class DumpJVR : IntegerCoordinateSystemActionBase2
    {
      private readonly string myOpts;
      private readonly Key<TimeSpan> myTime;

      public DumpJVR(string opts, Key<TimeSpan> time)
      {
        myOpts = opts;
        myTime = time;
      }

      protected override void Apply<_, Q1>(_ __, Context input, Context output)
      {        
        var log = Logger.Instance(input);
        var ctx = Keys.GraphMeasure<Q1>().Get(input);
        var time = myTime.Get(input).TotalMilliseconds;

        log.Write("Construct measure using: " + myOpts);
        log.Write(string.Format("measure time: {0}ms", time));
        log.Write(string.Format("measure entropy: {0}", ctx.GetEntropy()));
      }
    }
  }
}