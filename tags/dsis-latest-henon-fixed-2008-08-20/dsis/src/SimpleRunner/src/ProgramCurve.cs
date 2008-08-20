using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Line;

namespace DSIS.SimpleRunner
{
  public class ProgramCurve
  {
    public static void _Main(string[] args)
    {
      var sp = new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });
      var duffingSp = new DefaultSystemSpace(2, new[] { -4.3, -3 }, new[] { 4.3, 3 }, new long[] { 3, 3 });
      var log_sp = new DefaultSystemSpace(2, new double[] { 0, 0 }, new double[] { 1, 4 }, new long[] { 3, 3 });
      IAction henon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction ikeda = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
      //      IAction init = new LineInitialAction(0.001, new double[] {-2.6, -2.1}, new double[] {0.5, 0});
      IAction init =
        //        new LineInitialAction(0.001, new[] {0.63313, 0.18940634},
        //                              new[] {0.63313 + 0.01, 0.18940634 + 1.92*0.01});
        new LineInitialAction(0.001, new[] { 0.54890950520833448, -0.75236002604166552 },
                              new[] { 0.53588867187500056, -0.74991861979166552 });

      var gr = new ActionGraph();
      IAction wfBase = new WorkingFolderAction();

      //      BuildCurveLength(10, gr, init, wfBase, ikeda);
      BuildCurveLength(100, gr, init, wfBase, henon);

      gr.Execute();
    }

    private static void BuildCurveLength(int steps, IActionGraphBuilder gr, IAction init, IAction wfBase,
                                         IAction function)
    {
      int v = 0;
      IAction loop = new LoopAction("Curve", steps, key => new AgregateAction(bld =>
                                                                                {
                                                                                  IAction act = new LineAction();
                                                                                  IAction wf =
                                                                                    new LoopStepWorkingFolderAction(
                                                                                      key, "{0}");
                                                                                  IAction draw2 = new DrawLineAction();
                                                                                  var dumpLineAction =
                                                                                    new DumpLineAction();

                                                                                  bld.AddEdge(bld.Start, act);
                                                                                  bld.AddEdge(act, bld.End);
                                                                                  bld.AddEdge(wf, dumpLineAction);
                                                                                  bld.AddEdge(act, dumpLineAction);
                                                                                  bld.AddEdge(bld.Start, wf);
                                                                                  bld.AddEdge(wf, draw2);
                                                                                  bld.AddEdge(act, draw2);
                                                                                }));
      IAction draw = new DrawLineAction();

      var sysWf = new SystemWorkingFolderAction();
      IAction logger = new LoggerAction();


      gr.AddEdge(logger, init);
      gr.AddEdge(wfBase, sysWf);
      gr.AddEdge(sysWf, init);
      gr.AddEdge(sysWf, logger);
      gr.AddEdge(function, sysWf);
      gr.AddEdge(function, init);
      gr.AddEdge(init, loop);
      gr.AddEdge(sysWf, loop);
      gr.AddEdge(function, loop);
      gr.AddEdge(loop, draw);
      gr.AddEdge(sysWf, draw);
    }    
  }
}