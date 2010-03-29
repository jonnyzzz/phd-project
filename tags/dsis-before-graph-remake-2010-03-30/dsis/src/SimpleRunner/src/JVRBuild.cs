using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Performance;

namespace DSIS.SimpleRunner
{
  public class JVRBuild : SIBuild
  {
    protected override IActionEdgesBuilder CreateActionsAfterSI(AfterSIParams<ComputationData> afterSIParams)
    {
      if (afterSIParams.IsLast)
      {
        BuildJVRCall(afterSIParams.SiConstructionAction, afterSIParams.System, 1e-3);
        BuildJVRCall(afterSIParams.SiConstructionAction, afterSIParams.System, 1e-4);
        BuildJVRCall(afterSIParams.SiConstructionAction, afterSIParams.System, 1e-5);
      }
      return base.CreateActionsAfterSI(afterSIParams);
    }

    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      //TODO: Return some system to run with
      throw new System.NotImplementedException();
    }

    private static void BuildJVRCall(IActionEdgesBuilder siConstructionAction, IAction system, double eps)
    {
      var opts = new JVRMeasureOptions {IncludeSelfEdge = false, InitialWeight = EntropyLoopWeights.CONST, EPS = eps};
      var key = new RecordTimeAction(new JVRMeasureAction(opts), "XxX" + eps);
      siConstructionAction
        .Edge(key)
        .Edge(new DumpJVR(opts, key.Key)).With(x => x.Back(siConstructionAction)).With(x => x.Back(system))
        ;
    }

    private class DumpJVR : IntegerCoordinateSystemActionBase3
    {
      private readonly JVRMeasureOptions myOpts;
      private readonly Key<TimeSpan> myTime;

      public DumpJVR(JVRMeasureOptions opts, Key<TimeSpan> time)
      {
        myOpts = opts;
        myTime = time;
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        var ctx = Keys.GraphMeasure<Q>().Get(input);
        var graph = Keys.Graph<Q>().Get(input);
        var system = Keys.SystemInfoKey.Get(input);

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

        var sb = new StringBuilder();
        var time = myTime.Get(input).TotalMilliseconds;
        sb.AppendFormat(
          @"{0} & {1} & {2} & {3} & {4} & {5} \\", 
          system.PresentableName,
          graph.NodesCount, 
          graph.EdgesCount, 
          myOpts.EPS, 
          time, 
          ctx.GetEntropy()
          ).AppendLine();
        
        File.AppendAllText(@"e:\jvr.log", sb.ToString());
      }
    }
  }
}