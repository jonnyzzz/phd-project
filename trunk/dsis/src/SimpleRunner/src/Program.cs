using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Logistics;
using DSIS.Function.Predefined.VanDerPol;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Agregated;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Line;
using DSIS.SimpleRunner.parallel;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class Program
  {
    public static void _Main(string[] args)
    {
      var sp = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      var duffingSp = new DefaultSystemSpace(2, new[] {-4.3, -3}, new[] {4.3, 3}, new long[] {3, 3});
      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      ISimpleAction henon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction ikeda = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
//      IAction init = new LineInitialAction(0.001, new double[] {-2.6, -2.1}, new double[] {0.5, 0});
      ISimpleAction init =
//        new LineInitialAction(0.001, new[] {0.63313, 0.18940634},
//                              new[] {0.63313 + 0.01, 0.18940634 + 1.92*0.01});
        new LineInitialAction(0.001, new[] {0.54890950520833448, -0.75236002604166552},
                              new[] {0.53588867187500056, -0.74991861979166552});

      var gr = new ActionGraph();
      ISimpleAction wfBase = new WorkingFolderAction();

//      BuildCurveLength(10, gr, init, wfBase, ikeda);
      BuildCurveLength(100, gr, init, wfBase, henon);

      gr.Execute();
    }

    private static void BuildCurveLength(int steps, IActionGraphBuilder gr, IAction init, IAction wfBase,
                                         IAction function)
    {
      int v = 0;
      IAction loop = new LoopAction(steps, new AgregateAction(delegate(IActionGraphPartBuilder bld)
                                                                {
                                                                  ISimpleAction act = new LineAction();
                                                                  ISimpleAction wf =
                                                                    new CustomPrefixWorkingFolderAction((++v).ToString());
                                                                  ISimpleAction draw2 = new DrawLineAction();
                                                                  DumpLineAction dumpLineAction = new DumpLineAction();

                                                                  bld.AddEdge(bld.Start, act);
                                                                  bld.AddEdge(act, bld.End);                                                                  
                                                                  bld.AddEdge(wf, dumpLineAction);
                                                                  bld.AddEdge(act, dumpLineAction);
                                                                  bld.AddEdge(bld.Start, wf);
                                                                  bld.AddEdge(wf, draw2);
                                                                  bld.AddEdge(act, draw2);
                                                                }));
      ISimpleAction draw = new DrawLineAction();

      var sysWf = new SystemWorkingFolderAction();
      ISimpleAction logger = new LoggerAction();


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

    public static void Main(string[] args)
    {

      var duffingSp = new DefaultSystemSpace(2, new[] { -4.3, -3 }, new[] { 4.3, 3 }, new long[] { 3, 3 });

      var spIkedaCutted =
        new DefaultSystemSpace(2, new[] {-1.1, -1.5}, new[] {3.5, 1.8}, new[] {3, 3L});
      var sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      var spD =
        new DefaultSystemSpace(2, new double[] {-2, -2}, new double[] {2, 2}, new long[] {2, 2});

      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      var log_sp2 = new DefaultSystemSpace(2, new double[] {0, 3}, new[] {1, 3.7}, new long[] {3, 3});

      var log_sp1 = new DefaultSystemSpace(1, new double[] {0}, new double[] {1}, new long[] {3});


      ISimpleAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction systemHenonD = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.2, 0.2), spD);
      IAction systemHenonD_272 = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.272, 0.2), spD);
      IAction systemIked = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
      IAction systemIkedaCut =
        new SystemInfoAction(new RenameSystem(new IkedaFunctionSystemInfoDecorator(), "Ikeda Cut"), spIkedaCutted);
      IAction systenLogistic2 = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
      IAction systenLogistic2_x = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp2);
      IAction systenLogistic3569 = new SystemInfoAction(new LogisticSystemInfo(3.569), log_sp1);
      IAction systenLogistic4 = new SystemInfoAction(new LogisticSystemInfo(4), log_sp1);

      IAction duffing = new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(0.48, 0.27, -1), 15, 0.1),
                                             duffingSp);
      IAction vanderpol = new SystemInfoAction(new RungeKuttSolver(new VanDerPolSystemInfo(1), 15, 0.1),
                                             duffingSp);

      ISimpleAction wfBase = new WorkingFolderAction();

      IAction[] system = {systemHenon, /*systemHenonD, systemHenonD_272, systemIked, systemIkedaCut*/};

      var parallel = new SimpleParallel();

//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic3569, 1).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic4, 1).Do);
      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systemHenon, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, duffing, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, vanderpol, 2).Do);
//        parallel.DoParallel(new ComputeDelegate(wfBase, 0 + i, systenLogistic2_x).Do);
//      }
      /*for (int steps = 8; steps <= 15; steps++)
      {
        foreach (IAction action in system)
        {
          parallel.DoParallel(new ComputeDelegate(wfBase, steps, action, entropys).Do);          
        }        
      }*/
      parallel.WaitForEnd();
    }

    private static void Collect()
    {
      GCHelper.Collect();
    }

    private static T[] Fill<T>(T t, int dim)
    {
      var tt = new T[dim];
      for (var i = 0; i < dim; i++)
      {
        tt[i] = t;
      }
      return tt;
    }

    private static void ComputeEntropy(int dim, IAction wfBase, int steps, IAction system)
    {
      ISimpleAction a2 = new CreateCoordinateSystemAction();
      ISimpleAction a3 = new CreateInitialCellsAction();
      ISimpleAction a4 = new BuildSymbolicImageAction();
      ISimpleAction a5 = new ChainRecurrenctSimbolicImageAction();
      ISimpleAction method = new SetMethod(new BoxMethodSettings(0.1), Fill(2L, dim));

      var gr = new ActionGraph();

      var sysWf = new SystemWorkingFolderAction();
      var wf = new CustomPrefixWorkingFolderAction(steps.ToString());
      ISimpleAction logger = new LoggerAction();

      gr.AddEdge(system, wfBase);
      gr.AddEdge(system, sysWf);
      gr.AddEdge(wfBase, sysWf);
      gr.AddEdge(sysWf, wf);
      gr.AddEdge(wf, logger);

      gr.AddEdge(system, a2);
      gr.AddEdge(a2, a3);
      gr.AddEdge(a3, a4);
      gr.AddEdge(system, a4);

      gr.AddEdge(method, a4);
      gr.AddEdge(a4, a5);

      gr.AddEdge(a4, new DumpGraphInfoAction());
      gr.AddEdge(a5, new DumpGraphComponentsInfoAction());

      IAction buildIS = new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            var build =
              new SymbolicImageConstructionStep();
            bld.AddEdge(bld.Start, build);
            bld.AddEdge(build, bld.End);
            var b = new ParallelAction(new DumpGraphInfoAction(),
                                       new DumpGraphComponentsInfoAction(),
                                       new DumpMethodAction()
              );
            var p = new ProxyAction();
            bld.AddEdge(build, b);
            bld.AddEdge(bld.Start, p);
            bld.AddEdge(p, b);

            var dumpEntropy = new GraphEntropyLogAction();
            bld.AddEdge(build, dumpEntropy);
            bld.AddEdge(p, dumpEntropy);
          });

      buildIS = new BranchAction(buildIS, new AgregateAction(delegate(IActionGraphPartBuilder bld)
                                                               {
                                                                 ISimpleAction xa1 = new ReplaceContextAction(
                                                                   new SetMethod(
                                                                     new PointMethodSettings(Fill(2, dim), 0.1),
                                                                     Fill(1L, dim)));

                                                                 IAction xa2 = buildIS;
                                                                 IAction xa3 = EntropyAction(steps);

                                                                 ISimpleAction la = new LoopIndexIncrementAction();

                                                                 bld.AddEdge(bld.Start, xa1);
                                                                 bld.AddEdge(bld.Start, xa3);
                                                                 bld.AddEdge(bld.Start, la);

                                                                 bld.AddEdge(xa1, xa2);
                                                                 bld.AddEdge(la, xa2);
                                                                 bld.AddEdge(xa2, xa3);

                                                                 bld.AddEdge(xa2, bld.End);
                                                               }
                                            ));

      IAction step = new ChainAction(
        new LoopAction(steps, buildIS)
        );


      gr.AddEdge(wf, step);
      gr.AddEdge(logger, step);
      gr.AddEdge(a5, step);
      gr.AddEdge(system, step);
      gr.AddEdge(method, step);

      gr.Execute();
    }

    private static IAction EntropyAction(int steps)
    {
      return
        new AgregateAction(delegate(IActionGraphPartBuilder xgr)
                             {
                               ISimpleAction draw = new DrawChainRecurrentAction();
                               ISimpleAction xwf =
                                 new ReplaceContextAction(new LoopStepWorkingFolderAction("step-{0}"));
                               xgr.AddEdge(xgr.Start, xwf);

                               xgr.AddEdge(xgr.Start, new DumpContextAction("EntropyAction"));
                               xgr.AddEdge(xgr.Start, xwf);
                               xgr.AddEdge(xwf, draw);
                               var entropies = new Dictionary<IAction, string>();

                               var entropySmart = new StrangeEntropyEvaluatorParams(
                                 StrangeEvaluatorType.WeightSearch_1,
                                 StrangeEvaluatorStrategy.SMART,
                                 EntropyLoopWeights.CONST);
                               var entropyFirst = new StrangeEntropyEvaluatorParams(
                                 StrangeEvaluatorType.WeightSearch_1,
                                 StrangeEvaluatorStrategy.FIRST,
                                 EntropyLoopWeights.CONST);
                               var entropySmartF = new StrangeEntropyEvaluatorParams(
                                 StrangeEvaluatorType.WeightSearch_Filtering,
                                 StrangeEvaluatorStrategy.SMART,
                                 EntropyLoopWeights.CONST);
                               var entropySmartL = new StrangeEntropyEvaluatorParams(
                                 StrangeEvaluatorType.WeightSearch_Limited,
                                 StrangeEvaluatorStrategy.SMART,
                                 EntropyLoopWeights.CONST);

                               var combinatoricsEntropy = new StrangeEntropyEvaluatorParams(
                                 StrangeEvaluatorType.Combinatorics,
                                 StrangeEvaluatorStrategy.COMBINATORICS,
                                 EntropyLoopWeights.CONST);

                               StrangeEntropyEvaluatorParams[] entropys = {
                                                                            entropyFirst, //entropySmartL, 
                                                                            entropySmart,
                                                                            combinatoricsEntropy
                                                                          };


                               foreach (var _evaluatorParams in entropys)
                               {
                                 var evaluatorParams = _evaluatorParams;
                                 entropies.Add(new AgregateAction(
                                                 delegate(IActionGraphPartBuilder bld)
                                                   {
                                                     var entropy = EntropyForEachComponent(
                                                       DrawEntropyAction(steps,new StrangeEntropyAction()));

                                                     var pa = new ProxyAction();

                                                     bld.AddEdge(bld.Start, pa);
                                                     bld.AddEdge(pa, entropy);
                                                     bld.AddEdge(entropy, bld.End);
                                                     bld.AddEdge(new SetStrangeEntropyParamsAction(evaluatorParams), entropy);
                                                   }), evaluatorParams.PresentableName);
                               }
//                               entropies.Add(DrawEntropyAction(steps, new PathEntropyAction()), "Path");
                               entropies.Add(EntropyForEachComponent(DrawEntropyAction(steps, new JVRMeasureAction(new JVRMeasureOptions { IncludeSelfEdge = false }))), "JVR2");
                               entropies.Add(EntropyForEachComponent(DrawEntropyAction(steps, new JVRMeasureAction(new JVRMeasureOptions { IncludeSelfEdge = true }))), "JVR");
                               entropies.Add(EntropyForEachComponent(DrawEntropyAction(steps, new EigenEntropyAction())), "Eigen");

                               foreach (var pair in entropies)
                               {
                                 IAction entropy = pair.Key;
                                 IAction customWf = new CustomPrefixWorkingFolderAction(pair.Value);

                                 xgr.AddEdge(xgr.Start, entropy);
                                 xgr.AddEdge(xwf, customWf);
                                 xgr.AddEdge(customWf, entropy);
                               }
                               xgr.AddEdge(xgr.Start, xgr.End);
                             });
    }

    private static IAction EntropyForEachComponent(IAction doDrawAndCompute)
    {
      return
        new ForeachStrongComponentAction(
          new AgregateAction(
            delegate(IActionGraphPartBuilder xld)
              {
                xld.AddEdge(xld.Start, doDrawAndCompute);
                xld.AddEdge(doDrawAndCompute, xld.End);
                var wf = new LoopStepWorkingFolderAction("comp-{0}");
                xld.AddEdge(xld.Start, wf);
                xld.AddEdge(wf, doDrawAndCompute);
              }
            )
          );
    }

    private static IAction DrawEntropyAction(int steps, IAction entropy)
    {
      return new DumpContextProxy("EEE",
                                  new AgregateAction(
                                    delegate(IActionGraphPartBuilder bld)
                                      {
                                        bld.AddEdge(bld.Start, new DumpContextAction("DrawEntropyAction"));
                                        bld.AddEdge(bld.Start, new DumpGraphInfoAction());
                                        bld.AddEdge(bld.Start, new DumpGraphComponentsInfoAction());
                                        bld.AddEdge(bld.Start, entropy);

                                        IAction drawEntropy =
                                          new ParallelAction(
//                                            new DumpGraphAsMatrixForMa  pleAction(),
                                            new DrawEntropyMeasureWithBaseAction(),
//                                            new DumpEntropyParamsAction(),
//                                            new DumpEntropyValueAction(),
//                                            new DrawEntropyMeasure3dAction(),
//                                            new DrawEntropyMeasure3dWithBaseAction(),
//                                            new DrawEntropyMeasureColorMapAction(),
                                            new MeasureEntropyLogAction(),
                                            new DumpGraphMeasureAction2(),
                                            new DumpGraphMeasureAction()
                                            );

                                        var pa = new ProxyAction();
                                        bld.AddEdge(bld.Start, pa);
                                        bld.AddEdge(pa, drawEntropy);
                                        bld.AddEdge(entropy, drawEntropy);

                                        bld.AddEdge(drawEntropy, bld.End);

                                        IAction project = new LoopAction(steps,
                                                                         new AgregateAction(
                                                                           delegate(IActionGraphPartBuilder bl)
                                                                             {
                                                                               ISimpleAction proj =
                                                                                 new ProjectEntopryAction();
                                                                               bl.AddEdge(bl.Start, proj);
                                                                               bl.AddEdge(proj, bl.End);

                                                                               var b =
                                                                                 new MeasureEntropyLogAction(
                                                                                   "Project");
                                                                               IAction bb = new ParallelAction(
                                                                                 new DumpEntropyValueAction(
                                                                                   "Project"),
                                                                                 new DumpGraphMeasureAction2(),
                                                                                 new DumpGraphMeasureAction()
                                                                                 );
                                                                               bl.AddEdge(proj, b);
                                                                               bl.AddEdge(proj, bb);

                                                                               ISimpleAction action =
                                                                                 new SelectiveCopyAction(
                                                                                   FileKeys.WorkingFolderKey);
                                                                               bl.AddEdge(bl.Start, action);

                                                                               bl.AddEdge(action, b);
                                                                               bl.AddEdge(action, bb);
                                                                             }));

                                        bld.AddEdge(entropy, project);
                                        bld.AddEdge(pa, project);
                                      }));
    }

    #region Nested type: ComputeDelegate

    private class ComputeDelegate
    {
      private readonly IAction action;
      private readonly int myDim;
      private readonly int steps;
      private readonly IAction wfBase;

      public ComputeDelegate(IAction wfBase, int steps, IAction action, int dim)
      {
        this.wfBase = wfBase;
        myDim = dim;
        this.steps = steps;
        this.action = action;
      }

      public void Do()
      {
        ComputeEntropy(myDim, wfBase, steps, action);
        Collect();
      }
    }

    #endregion
  }
}