using System;
using System.Collections.Generic;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.Scheme.Xml;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public static class SIBuild
  {
    public static void Action()
    {
      BuildContiniousSystems();
    }

    private static List<ComputationData> ForBuildser(IEnumerable<ComputationData> data, params Builder[] bld)
    {
      var d = new List<ComputationData>();
      foreach (var computationData in data)
      {
        foreach (var b in bld)
        {
          var dd = computationData.Clone();
          dd.builder = b;
          d.Add(dd);
        }
      }
      return d;
    }

    private static void BuildContiniousSystems()
    {
      for (int rep = 3; rep < 5; rep++)
      {
        var data = ForBuildser(new List<ComputationData>
                     {
                       new ComputationData {system = SystemInfoFactory.DuffingRunge(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.FoodChainDanny(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.VanDerPolRunge(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.LorentzRunge(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.RosslerRunge(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.BrusselatorRunge(), repeat = rep},
                       new ComputationData {system = SystemInfoFactory.ChuaRunge(), repeat = rep},
                     }, Builder.Point, Builder.Box);
        foreach (var computationData in new List<ComputationData>(data))
        {
          try
          {
            var sys = computationData;
            var aa = new AgregateAction(x => BuildGraph(new ActionBuilder2Adaptor(x), sys));
            aa.Apply(new Context());
            Console.Out.WriteLine("---------------------------------------------------------");
          } catch (OutOfMemoryException e)
          {
            Console.Out.WriteLine("-----------------------------OOE-------------------------");
            Console.Out.WriteLine(e); 
            Console.Out.WriteLine("-----------------------------OOE-------------------------");
            data.Remove(computationData);
          }
          GCHelper.Collect();
        }
      }
    }

    private enum Builder
    {
      Box,
      Adaptive,
      Point
    }

    private struct ComputationData
    {
      public IAction system { get; set; }
      public int repeat { get; set; }
      public Builder builder { get; set; }

      public ComputationData Clone()
      {
        return new ComputationData
                 {
                   system = system,
                   repeat = repeat,
                   builder = builder
                 };
      }
    }

    private static void BuildGraph(IActionGraphBuilder2 bld, ComputationData sys)
    {
      var graphs = new XsdGraphXmlLoader().Load(typeof (SIBuild).Assembly, "DSIS.SimpleRunner.resources.si.xml");
      var builder = new XsdGraphBuilder().BuildActions(graphs);

      var image = builder["imageBuilder" + sys.builder];
      var init = builder["init"];
      var workingFolder = builder["workingFolder"];
      var dump = builder["dumpGraph"];
      var draw = builder["drawGraph"];

      var id = new SetIterationSteps(new IterationSteps(sys.repeat));
      bld.Start.Edge(sys.system).Edge(init).Edge(image);
      bld.Start.Edge(sys.system).Edge(workingFolder).With(x => x.Back(id));

      var rootAction = RepeatSI(
        bld.Start,
        sys.repeat,
        builder["build"],
        new[] {sys.system, image, init},
        new[] {sys.system, image});

      rootAction
        .With(x => x.Edge(dump).
                     With(xx => xx.Back(image)).
                     With(xx => xx.Back(workingFolder).Back(image)))
        .Edge(draw).
        With(x => x.Back(workingFolder))
        .Edge(bld.Finish).Back(new DumpSlotTimesAction("BuildSI"));
      ;
    }

    private static IActionEdgesBuilder RepeatSI(IActionEdgesBuilder holder, int count, IAction buildSI,
                                                IEnumerable<IAction> firstContext, IEnumerable<IAction> innerContext)
    {
      if (count < 2)
        throw new ArgumentException("Count should be >= 2", "count");

      var next = holder.Edge(buildSI.Clone()).With(x => firstContext.Each(y => x.Back(y)));
      for (int i = 1; i < count; i++)
      {
        var tmp = next;
        next = next
          .Edge(buildSI.Clone())
          .With(x => innerContext.Each(y => x.Back(y)))
          .With(x => x.Back(new MergeComponetsAction()).Back(tmp));
      }

      return next;
    }
  }
}