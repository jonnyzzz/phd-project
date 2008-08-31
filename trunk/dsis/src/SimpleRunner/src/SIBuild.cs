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

//      var system = SystemInfoFactory.Henon1_4();
      var system = SystemInfoFactory.LorentzRunge();
      var repeat = 5;

      bld.Start.Edge(system).Edge(init).Edge(image);
      bld.Start.Edge(system).Edge(workingFolder);

      var rootAction = RepeatSI(bld.Start, repeat, builder["build"], new[]{system, image, init}, new[]{system,image});

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