using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Morse;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Performance;

namespace DSIS.SimpleRunner
{
  public class JVRDetMorseBuild : SIBuild
  {
    protected override IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction, IAction system, bool isLast)
    {
      if (isLast)
      {
        BuildJVRCall(siConstructionAction, system, 1e-3);
        BuildJVRCall(siConstructionAction, system, 1e-4);
        BuildJVRCall(siConstructionAction, system, 1e-5);
        BuildJVRCall(siConstructionAction, system, 1e-8);
      }
      return base.CreateActionsAfterSI(siConstructionAction, system, isLast);
    }

    private static void BuildJVRCall(IActionEdgesBuilder siConstructionAction, IAction system, double eps)
    {
      var opts = new MorseEvaluatorOptions {Eps = eps};
      var key = new RecordTimeAction(new JVRMorseAction(opts), "XxX" + eps);
      siConstructionAction
        .Edge(key).With(x=>x.Back(system))
        .Edge(new DumpJVR(opts, key.Key)).With(x => x.Back(siConstructionAction)).With(x => x.Back(system))
        ;
    }

    private class DumpJVR : IntegerCoordinateSystemActionBase3
    {
      private readonly MorseEvaluatorOptions myOpts;
      private readonly Key<TimeSpan> myTime;

      public DumpJVR(MorseEvaluatorOptions opts, Key<TimeSpan> time)
      {
        myOpts = opts;
        myTime = time;
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        var graph = Keys.Graph<Q>().Get(input);
        var comps = Keys.GraphComponents<Q>().Get(input);
        var system = Keys.SystemInfoKey.Get(input);

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

        var sb = new StringBuilder();
        var time = myTime.Get(input).TotalMilliseconds;
        sb.AppendFormat(
          @"{0}, nodes:{1}, edges:{2}, components:{3}, time:{4}, eps:{5}", 
          system.PresentableName,
          graph.NodesCount, 
          graph.EdgesCount, 
          comps.ComponentCount,
          time, 
          myOpts.Eps
          ).AppendLine();

        var result = Keys.Morse<Q>().Get(input);

        foreach (var comp in comps.Components)
        {
          sb.Append("  ");
          sb.AppendFormat("nodes:{0}, edges{1} ", comp.NodesCount, EdgesCount(comp, comps));

          var val = result.Get(comp);

          sb.AppendFormat("min: v={0},length={1} ", val.Min.Value, val.Min.Contour.Count);
          sb.AppendFormat("max: v={0},length={1} ", val.Max.Value, val.Max.Contour.Count);
          sb.AppendLine();
        }
        sb.AppendLine();
        
        File.AppendAllText(@"e:\jvr_morse.log", sb.ToString());
      }

      private static int EdgesCount<Q>(IStrongComponentInfo info, IGraphStrongComponents<Q> cms) 
        where Q : ICellCoordinate
      {
        return cms.GetNodes(new[] {info}).Aggregate(0,
                                                    (v, x) => v + cms.GetEdgesWithFilteredEdges(x, new[] {info}).Count());
      }
    }
  }
}