using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Logistics;
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
    public static void Mai0n(string[] args)
    {
      DefaultSystemSpace sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      DefaultSystemSpace log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      ISimpleAction henon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction ikeda = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
//      IAction init = new LineInitialAction(0.001, new double[] {-2.6, -2.1}, new double[] {0.5, 0});
      ISimpleAction init =
        new LineInitialAction(0.001, new double[] {0.63313, 0.18940634},
                              new double[] {0.63313 + 0.01, 0.18940634 + 1.92*0.01});
      ActionGraph gr = new ActionGraph();
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

                                                                  bld.AddEdge(bld.Start, act);
                                                                  bld.AddEdge(act, bld.End);
                                                                  bld.AddEdge(act, new DumpLineAction());
                                                                  bld.AddEdge(bld.Start, wf);
                                                                  bld.AddEdge(wf, draw2);
                                                                  bld.AddEdge(act, draw2);
                                                                }));
      ISimpleAction draw = new DrawLineAction();

      SystemWorkingFolderAction sysWf = new SystemWorkingFolderAction();
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

    public static void Main()
    {
      DefaultSystemSpace spIkedaCutted =
        new DefaultSystemSpace(2, new double[] {-1.1, -1.5}, new double[] {3.5, 1.8}, new long[] {3, 3});
      DefaultSystemSpace sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      DefaultSystemSpace spD =
        new DefaultSystemSpace(2, new double[] {-2, -2}, new double[] {2, 2}, new long[] {2, 2});

      DefaultSystemSpace log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      DefaultSystemSpace log_sp2 =
        new DefaultSystemSpace(2, new double[] {0, 3}, new double[] {1, 3.7}, new long[] {3, 3});


      ISimpleAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction systemHenonD = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.2, 0.2), spD);
      IAction systemHenonD_272 = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.272, 0.2), spD);
      IAction systemIked = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
      IAction systemIkedaCut =
        new SystemInfoAction(new RenameSystem(new IkedaFunctionSystemInfoDecorator(), "Ikeda Cut"), spIkedaCutted);
      IAction systenLogistic2 = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
      IAction systenLogistic2_x = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp2);

      ISimpleAction wfBase = new WorkingFolderAction();

      IAction[] system = {systemHenon, /*systemHenonD, systemHenonD_272, systemIked, systemIkedaCut*/};

      SimpleParallel parallel = new SimpleParallel();

//        parallel.DoParallel(
      new ComputeDelegate(wfBase, 7, systemHenon).Do();
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

    private class ComputeDelegate
    {
      private readonly ISimpleAction wfBase;
      private readonly int steps;
      private readonly ISimpleAction action;

      public void Do()
      {
        ComputeEntropy(wfBase, steps, action);
        Collect();
      }

      public ComputeDelegate(ISimpleAction wfBase, int steps, ISimpleAction action)
      {
        this.wfBase = wfBase;
        this.steps = steps;
        this.action = action;
      }
    }

    private static void Collect()
    {
      GCHelper.Collect();
    }

    private static void ComputeEntropy(IAction wfBase, int steps, IAction system)
    {
      ISimpleAction a2 = new CreateCoordinateSystemAction();
      ISimpleAction a3 = new CreateInitialCellsAction();
      ISimpleAction a4 = new BuildSymbolicImageAction();
      ISimpleAction a5 = new ChainRecurrenctSimbolicImageAction();
      ISimpleAction method = new SetMethod(new BoxMethodSettings(0.1), new long[] {2, 2});

      ActionGraph gr = new ActionGraph();

      SystemWorkingFolderAction sysWf = new SystemWorkingFolderAction();
      CustomPrefixWorkingFolderAction wf = new CustomPrefixWorkingFolderAction(steps.ToString());
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
            SymbolicImageConstructionStep build =
              new SymbolicImageConstructionStep();
            bld.AddEdge(bld.Start, build);
            bld.AddEdge(build, bld.End);
            ParallelAction b = new ParallelAction(new DumpGraphInfoAction(),
                                                  new DumpGraphComponentsInfoAction(),
                                                  new DumpMethodAction()
              );
            ProxyAction p = new ProxyAction();
            bld.AddEdge(build, b);
            bld.AddEdge(bld.Start, p);
            bld.AddEdge(p, b);

            GraphEntropyLogAction dumpEntropy = new GraphEntropyLogAction();
            bld.AddEdge(build, dumpEntropy);
            bld.AddEdge(p, dumpEntropy);

            Collect();
          });

      buildIS = new BranchAction(buildIS, new AgregateAction(delegate(IActionGraphPartBuilder bld)
                                                               {
                                                                 ISimpleAction xa1 = new ReplaceContextAction(
                                                                   new SetMethod(
                                                                     new PointMethodSettings(new int[] {2, 2}, 0.1),
                                                                     new long[] {2, 2}));

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

    private static AgregateAction EntropyAction(int steps)
    {
      return new AgregateAction(delegate(IActionGraphPartBuilder xgr)
                                  {
                                    ISimpleAction draw = new DrawChainRecurrentAction();
                                    ISimpleAction xwf =
                                      new ReplaceContextAction(new LoopStepWorkingFolderAction("step-{0}"));
                                    xgr.AddEdge(xgr.Start, xwf);

                                    xgr.AddEdge(xgr.Start, xwf);
                                    xgr.AddEdge(xwf, draw);
                                    Dictionary<IAction, string> entropies = new Dictionary<IAction, string>();

                                    StrangeEntropyEvaluatorParams entropySmart = new StrangeEntropyEvaluatorParams(
                                      StrangeEvaluatorType.WeightSearch_1,
                                      StrangeEvaluatorStrategy.SMART,
                                      EntropyLoopWeights.CONST);
                                    StrangeEntropyEvaluatorParams entropyFirst = new StrangeEntropyEvaluatorParams(
                                      StrangeEvaluatorType.WeightSearch_1,
                                      StrangeEvaluatorStrategy.FIRST,
                                      EntropyLoopWeights.CONST);
                                    StrangeEntropyEvaluatorParams entropySmartF = new StrangeEntropyEvaluatorParams(
                                      StrangeEvaluatorType.WeightSearch_Filtering,
                                      StrangeEvaluatorStrategy.SMART,
                                      EntropyLoopWeights.CONST);
                                    StrangeEntropyEvaluatorParams entropySmartL = new StrangeEntropyEvaluatorParams(
                                      StrangeEvaluatorType.WeightSearch_Limited,
                                      StrangeEvaluatorStrategy.SMART,
                                      EntropyLoopWeights.CONST);

                                    StrangeEntropyEvaluatorParams[] entropys = {
                                                                                 entropyFirst, //entropySmartL, 
                                                                                 entropySmart
                                                                               };


                                    foreach (StrangeEntropyEvaluatorParams evaluatorParams in entropys)
                                    {
                                      entropies.Add(new AgregateAction(delegate(IActionGraphPartBuilder bld)
                                                                         {
                                                                           IAction entropy = new ParallelAction(
                                                                             //          new ForeachStrongComponentAction(
                                                                             DrawEntropyAction(steps,
                                                                                               new StrangeEntropyAction()));
                                                                           //          DrawEntropyAction(new PathEntropyAction());

                                                                           ProxyAction pa = new ProxyAction();

                                                                           bld.AddEdge(bld.Start, pa);
                                                                           bld.AddEdge(pa, entropy);
                                                                           bld.AddEdge(entropy, bld.End);
                                                                           bld.AddEdge(
                                                                             new SetStrangeEntropyParamsAction(
                                                                               evaluatorParams), entropy);
                                                                         }), evaluatorParams.PresentableName);
                                    }
                                    //      entropies.Add(DrawEntropyAction(steps, new PathEntropyAction()), "Path");
                                    //      entropies.Add(DrawEntropyAction(steps, new JVRMeasureAction()), "JVR");

                                    foreach (KeyValuePair<IAction, string> pair in entropies)
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

    private static IAction DrawEntropyAction(int steps, IAction entropy)
    {
      return new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            bld.AddEdge(bld.Start, new DumpGraphInfoAction());
            bld.AddEdge(bld.Start, new DumpGraphComponentsInfoAction());
            bld.AddEdge(bld.Start, entropy);

            IAction drawEntropy =
              new ParallelAction(
//                new DumpEntropyParamsAction(),
                new DumpEntropyValueAction(),
                new DrawEntropyMeasure3dAction(),
                new DrawEntropyMeasure3dWithBaseAction(),
                new DrawEntropyMeasureColorMapAction(),
                new MeasureEntropyLogAction(),
                new DumpGraphMeasureAction2(),
                new DumpGraphMeasureAction()
                );
            ProxyAction pa = new ProxyAction();
            bld.AddEdge(bld.Start, pa);
            bld.AddEdge(pa, drawEntropy);
            bld.AddEdge(entropy, drawEntropy);

            bld.AddEdge(drawEntropy, bld.End);

            IAction project = new LoopAction(steps, new AgregateAction(delegate(IActionGraphPartBuilder bl)
                                                                         {
                                                                           ISimpleAction proj =
                                                                             new ProjectEntopryAction();
                                                                           bl.AddEdge(bl.Start, proj);
                                                                           bl.AddEdge(proj, bl.End);

                                                                           MeasureEntropyLogAction b =
                                                                             new MeasureEntropyLogAction("Project");
                                                                           IAction bb = new ParallelAction(
                                                                             new DumpEntropyValueAction("Project"),
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
          });
    }
  }
}