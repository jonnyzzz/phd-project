using System;
using System.Collections.Generic;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Xml;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public static class SIBuild
  {
    public static void Action()
    {
      var aa = new AgregateAction(x => BuildGraph(new ActionBuilder2Adaptor(x)));
      aa.Apply(new Context());
    }

    private static void BuildGraph(IActionGraphBuilder2 bld)
    {
      var graphs = new XsdGraphXmlLoader().Load(typeof(SIBuild).Assembly, "DSIS.SimpleRunner.resources.si.xml");
      var builder = new XsdGraphBuilder().BuildActions(graphs);

      var image = builder["imageBuilder"];
      var init = builder["init"];
      var workingFolder = builder["workingFolder"];
      var dump = builder["dumpGraph"];
      var draw = builder["drawGraph"];

//      var sys = new {system = SystemInfoFactory.VanDerPolRunge(), repeat = 10};
//      var sys = new {system = SystemInfoFactory.LorentzRunge(), repeat = 8};
      var sys = new {system = SystemInfoFactory.DuffingRunge(), repeat = 10};

      bld.Start.Edge(sys.system).Edge(init).Edge(image);
      bld.Start.Edge(sys.system).Edge(workingFolder);

      var rootAction = RepeatSI(
        bld.Start, 
        sys.repeat, 
        builder["build"], 
        new[]{sys.system, image, init}, 
        new[]{sys.system,image});

      rootAction
        .With(x=>x.Edge(dump).
          With(xx=>xx.Back(image)).
          With(xx=>xx.Back(workingFolder)))
        .Edge(draw).
          With(x=>x.Back(workingFolder))
        .Edge(bld.Finish)
        ;
    }

    private static IActionEdgesBuilder RepeatSI(IActionEdgesBuilder holder, int count, IAction buildSI, IEnumerable<IAction> firstContext, IEnumerable<IAction> innerContext)
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
            .With(x=>x.Back(new MergeComponetsAction()).Back(tmp));
      }

      return next;
    }
  }
}