using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.HomoLinear;
using DSIS.Function.Predefined.HomoSquare;
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
using DSIS.SimpleRunner.parallel;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var duffingSp = new DefaultSystemSpace(2, new[] {-4.3, -3}, new[] {4.3, 3}, new long[] {3, 3});

      var spIkedaCutted =
        new DefaultSystemSpace(2, new[] {-1.1, -1.5}, new[] {3.5, 1.8}, new[] {3, 3L});
      var sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      var spD =
        new DefaultSystemSpace(2, new double[] {-2, -2}, new double[] {2, 2}, new long[] {2, 2});

      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      var log_sp2 = new DefaultSystemSpace(2, new double[] {0, 3}, new[] {1, 3.7}, new long[] {3, 3});

      var log_sp1 = new DefaultSystemSpace(1, new double[] {0}, new double[] {1}, new long[] {3});


      IAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction systemHenonD = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.2, 0.2), spD);
      IAction systemHenonD_272 = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.272, 0.2), spD);
      IAction systemIked = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
      IAction systemIkedaCut =
        new SystemInfoAction(new RenameSystem(new IkedaFunctionSystemInfoDecorator(), "Ikeda Cut"), spIkedaCutted);
      IAction systenLogistic2 = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
      IAction systenLogistic2_x = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp2);
      IAction systenLogistic3569 = new SystemInfoAction(new LogisticSystemInfo(3.569), log_sp1);
      IAction systenLogistic4 = new SystemInfoAction(new LogisticSystemInfo(4), log_sp1);
      IAction systenHomoLinear = new SystemInfoAction(new HomoLinearSystemInfo(1.35), sp);
      IAction systenHomoSquare = new SystemInfoAction(new HomoSquareSystemInfo(0.4), sp);

      IAction duffing = new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01), 3, 0.01),
                                             duffingSp);
      IAction vanderpol = new SystemInfoAction(new RungeKuttSolver(new VanDerPolSystemInfo(1), 15, 0.1),
                                               duffingSp);

      IAction wfBase = new WorkingFolderAction();

      IAction[] system = {systemHenon, /*systemHenonD, systemHenonD_272, systemIked, systemIkedaCut*/};

      var parallel = new SimpleParallel();

//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic3569, 1).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic4, 1).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 8, systenHomoLinear, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 8, systenHomoSquare, 2).Do);
      parallel.DoParallel(new ComputeDelegate(wfBase, 5, duffing, 2).Do); 
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systemHenon, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 10, systemIked, 2).Do);
      
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

    private static void ComputeEntropy(int dim, IAction wfBase, int steps, IAction system)
    {
      IAction a2 = new CreateCoordinateSystemAction();
      IAction a3 = new CreateInitialCellsAction();
      IAction a4 = new BuildSymbolicImageAction();
      IAction a5 = new ChainRecurrenctSimbolicImageAction();
      IAction method = new SetMethod(new BoxMethodSettings(0.1), 2L.Fill(dim));

      var gr = new ActionGraph();

      var sysWf = new SystemWorkingFolderAction();
      var wf = new CustomPrefixWorkingFolderAction(steps.ToString());
      IAction logger = new LoggerAction();

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

      IAction step = new ChainAction(
        new LoopAction("step", steps,
                       x => new BranchAction(
                              buildIS,
                              new AgregateAction(
                                bld =>
                                  {
                                    IAction xa1 = new ProxyAction(); var xxx= new ReplaceContextAction(
                                       new SetMethod(
                                         new PointMethodSettings(2.Fill(dim), 0.1), 1L.Fill(dim)));
                                    IAction xa2 = buildIS;
                                    IAction xa3 = EntropyAction(x, steps);

                                    IAction la = new LoopIndexIncrementAction(x);

                                    bld.AddEdge(bld.Start, xa1);
                                    bld.AddEdge(bld.Start, xa3);
                                    bld.AddEdge(bld.Start, la);

                                    bld.AddEdge(xa1, xa2);
                                    bld.AddEdge(la, xa2);
                                    bld.AddEdge(xa2, xa3);

                                    bld.AddEdge(xa2, bld.End);
                                  }
                                )))
        );


      gr.AddEdge(wf, step);
      gr.AddEdge(logger, step);
      gr.AddEdge(a5, step);
      gr.AddEdge(system, step);
      gr.AddEdge(method, step);


      var writeSequenceSlotAction = new WriteSequenceSlotAction();
      gr.AddEdge(step, writeSequenceSlotAction);
      gr.AddEdge(a5, writeSequenceSlotAction);
      gr.Execute();
    }

    private static IAction EntropyAction(ILoopAction loop, int steps)
    {
      return
        new AgregateAction(delegate(IActionGraphPartBuilder xgr)
                             {
                               IAction draw = new DrawChainRecurrentAction();
                               IAction xwf =
                                 new ReplaceContextAction(new LoopStepWorkingFolderAction(loop, "step-{0}"));
                               xgr.AddEdge(xgr.Start, xwf);

                               xgr.AddEdge(xgr.Start, new DumpContextAction("EntropyAction"));
                               xgr.AddEdge(xgr.Start, xwf);
                               xgr.AddEdge(xwf, draw);
                               
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
                               var entropies =
                                 new Dictionary<IAction, string>
                                   {
                                     {
                                       new JVRMeasureAction(new JVRMeasureOptions
                                                              {
                                                                IncludeSelfEdge = false,
                                                                InitialWeight = EntropyLoopWeights.CONST
                                                              }), "JVR2-Const"
                                       },
//                                     {
//                                       new JVRMeasureAction(new JVRMeasureOptions
//                                                              {
//                                                                IncludeSelfEdge = false,
//                                                                InitialWeight = EntropyLoopWeights.ONE
//                                                              }), "JVR2-One"
//                                       },
//                                     {
//                                       new JVRMeasureAction(new JVRMeasureOptions
//                                                              {
//                                                                IncludeSelfEdge = false,
//                                                                InitialWeight = EntropyLoopWeights.MINUS_ONE
//                                                              }), "JVR2-MinusOne"
//                                       },
                                     { new EigenEntropyAction(), "Eigen" }
                                   };

                               /*               foreach (var _evaluatorParams in entropys)
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
                               }*/
//                               entropies.Add(DrawEntropyAction(steps, new PathEntropyAction()), "Path");
//                               entropies.Add(EntropyForEachComponent(loop, DrawEntropyAction(steps, new JVRMeasureAction(new JVRMeasureOptions { IncludeSelfEdge = true }))), "JVR");

/*
                               foreach (var pair in entropies)
                               {
                                 IAction entropy = EntropyForEachComponent(DrawEntropyAction(pair.Value, loop, steps, pair.Key));
                                 IAction customWf = new CustomPrefixWorkingFolderAction(pair.Value);

                                 xgr.AddEdge(xgr.Start, entropy);
                                 xgr.AddEdge(xwf, customWf);
                                 xgr.AddEdge(customWf, entropy);
                               }
*/
                               xgr.AddEdge(xgr.Start, xgr.End);
                             });
    }

    private static IAction EntropyForEachComponent(IAction doDrawAndCompute)
    {
      return
        new ForeachStrongComponentAction("foreach_componen",
          x => new AgregateAction(
            delegate(IActionGraphPartBuilder xld)
              {
                xld.AddEdge(xld.Start, doDrawAndCompute);
                xld.AddEdge(doDrawAndCompute, xld.End);
                var wf = new LoopStepWorkingFolderAction(x, "comp-{0}");
                xld.AddEdge(xld.Start, wf);
                xld.AddEdge(wf, doDrawAndCompute);
              }
            )
          );
    }

    private static IAction DrawEntropyAction(string entropyMethod, ILoopAction loop, int steps, IAction entropy)
    {
      return new DumpContextProxy("DrawEntropyAction", new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            IActionGraphBuilder2 bld2 = new ActionBuilder2Adaptor(bld);
//            bld2.Start.Edge(new DumpContextAction("DrawEntropyAction-" + entropyMethod));
            bld2.Start.Edge(new DumpGraphInfoAction());
            bld2.Start.Edge(new DumpGraphComponentsInfoAction());

            bld2.Start
              .Edge(entropy)
              .With(x => x.Edge(new DrawEntropyMeasureWithBaseAction()).Back(bld2.Start))
              .Edge(EntropyProjectAction(entropyMethod, steps, loop)).With(x => x.Back(bld2.Start))
              .Edge(bld2.Finish);
          }));
    }

    private static LoopAction EntropyProjectAction(string method, int steps, ILoopAction loop)
    {
      return new LoopAction(
        "proj",
        steps, projStep =>
               new AgregateAction(
                 delegate(IActionGraphPartBuilder bl)
                   {
                     IActionGraphBuilder2 bl2 = new ActionBuilder2Adaptor(bl);

                     bl2.Start
                       .With(x => x
                                    .Edge(new DumpContextProxy("After Entropy" + method,
                                                               new ParallelAction(
//                                    new DumpGraphAsMatrixForMapleAction(),

//                                    new DumpEntropyParamsAction(),
//                                    new DumpEntropyValueAction(),
//                                    new DrawEntropyMeasure3dAction(),
//                                    new DrawEntropyMeasure3dWithBaseAction(),
//                                    new DrawEntropyMeasureColorMapAction(),
                                                                 new MeasureEntropyLogAction(),
//                                                                 new DumpGraphMeasureAction2(),
//                                                                 new DumpGraphMeasureAction(),
                                                                 new DumpEntropyValueAction("Project"),
                                                                 new InsertMeasureToSlotAction(method, loop, projStep)
                                                                 ))
                                    ).With(xx => xx
                                                   .Back(new SelectiveCopyAction(
                                                           FileKeys.WorkingFolderKey,
                                                           loop.Key,
                                                           projStep.Key
                                                           )
                                                   )
                                                   .Back(bl2.Start)
                                    )
                       )
                       .With(x => x
                                    .Edge(new ProjectEntopryAction())
                                    .Edge(bl2.Finish)
                       );
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