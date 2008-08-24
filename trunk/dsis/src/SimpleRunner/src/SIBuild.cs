using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Xml;

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
      var rootAction = builder["build"];
      var init = builder["init"];
      var workingFolder = builder["workingFolder"];
      var dump = builder["dumpGraph"];
      var draw = builder["drawGraph"];

      var system = SystemInfoFactory.Henon1_4();


      bld.Start.Edge(system).Edge(init).Edge(image);
      bld.Start.Edge(system).Edge(workingFolder);

      bld.Start
        .Edge(rootAction).
          With(x=>x.Back(system)).
          With(x=>x.Back(image)).
          With(x=>x.Back(init))
        .With(x=>x.Edge(dump).
          With(xx=>xx.Back(image)).
          With(xx=>xx.Back(workingFolder)))
        .Edge(draw).
          With(x=>x.Back(workingFolder))
        .Edge(bld.Finish)
        ;
    }
  }
}