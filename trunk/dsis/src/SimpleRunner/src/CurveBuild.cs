using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Line;
using DSIS.Scheme.Impl.Actions.Performance;

namespace DSIS.SimpleRunner
{
  public abstract class CurveBuild : BuilderBase<CurveBuilderData>
  {
    protected override void BuildGraph(IActionGraphBuilder2 bld, CurveBuilderData sys)
    {
      var init = new LineInitialAction(
        sys.eps, 
        sys.Point1,
        sys.Point2
        );
      DoBuildGraph(sys.repeat, bld, sys.system, init);
    }

    private static void DoBuildGraph(int steps, IActionGraphBuilder2 bld, IAction system, IAction init)
    {
      var wfBase = new FlatWorkingFolder();
      var wfLine = new CustomPrefixWorkingFolderAction("Line");       
      var wfNext = new SystemWorkingFolderAction();
      var wfSteps = new CustomPrefixWorkingFolderAction(steps.ToString()); 
      var wfIt = new DateWorkingFolderAction();
      
      var wf = bld.Start.Edge(wfBase).Edge(wfLine).Edge(wfNext).WithBack(system).Edge(wfSteps).Edge(wfIt);
      
      wf.Edge(new DumpWorkingFolderAction());

      BuildCurveLength(steps, init, wf, system, bld.Finish);
    }

    private static void BuildCurveLength(int steps, IAction initA, IActionEdgesBuilder wfBase, IAction function, IActionEdgesBuilder END)
    {
      const string curveAction = "curve";
      const string curvePref = "perf";

      IAction loopA = new LoopAction(
        "Curve",
        steps,
        key => new AgregateAction(
                 bld =>
                   {
                     var act = bld.Start.Edge(new RecordTimeSlotAction(new LineAction(), curvePref));
                     var wf = bld.Start.Edge(new LoopStepWorkingFolderAction(key, "{0}"));
                     var logger2 = wf.Edge(new LoggerAction());

                     var idx = bld.Start.Edge(new CopyContextKeysAction(key.Key));

                     act.Edge(new AddLineLengthSlotAction(curveAction, key)).WithBack(idx).Edge(bld.Finish);
                     
                     act.Edge(bld.Finish);
                     logger2.Edge(new DumpLineAction()).Back(act);
                   }));

      var logger = wfBase.Edge(new LoggerAction());

      var init = logger.Edge(initA).WithBack(wfBase).WithBack(function);

      var draw = wfBase.Edge(new DrawLineAction()).WithBack(wfBase);

      var loop = init.Edge(loopA);
      loop.Edge(new DumpLineEntropySlotAction(curveAction)).Edge(END);

      loop.WithBack(wfBase, logger).WithBack(function).Edge(draw).Edge(END);

      END.Back(new DumpSlotTimesAction(curvePref)).Back(logger);
    }
  }
}