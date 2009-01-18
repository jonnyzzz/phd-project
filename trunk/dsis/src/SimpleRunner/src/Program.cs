using System.Collections.Generic;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.FoodChain;
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
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions;
using DSIS.Scheme.Impl.Actions.Agregated;
using DSIS.Scheme.Impl.Actions.Console;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.SimpleRunner.parallel;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class Program
  {
    public static void Main(string[] args)
    {
      new JVRBuild().Action();
      return;
      var wfBase = new WorkingFolderAction();

      var parallel = new SimpleParallel();

//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic3569, 1).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 12, systenLogistic4, 1).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 8, systenHomoLinear, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 8, systenHomoSquare, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 10, duffing, 2).Do); 
      parallel.DoParallel(new ComputeDelegate(wfBase, 12, SystemInfoFactory.Henon1_4(), 2).Do);

//      parallel.DoParallel(new ComputeDelegate(wfBase, 9, systemIked, 2).Do);
//      parallel.DoParallel(new ComputeDelegate(wfBase, 8, systemTorsten, 3).Do);
      
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
      const string timeSlotKey = "BuildSymbolicImage";

      IAction a2 = new CreateCoordinateSystemAction();
      IAction a3 = new CreateInitialCellsAction();
      IAction a4 = new RecordTimeSlotAction(new BuildSymbolicImageAction(), timeSlotKey);
      IAction a5 = new ChainRecurrenctSimbolicImageAction();
      IAction method = new DefaultBoxMethodSettings(); //!

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

      gr.AddEdge(a3, method);
      gr.AddEdge(method, a4);
      gr.AddEdge(a4, a5);

      gr.AddEdge(a4, new DumpGraphInfoAction());
      
      var dumpGraphComponents = new DumpGraphComponentsInfoAction();
      gr.AddEdge(a5, dumpGraphComponents);
      gr.AddEdge(a4, dumpGraphComponents);

      IAction buildIS = new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            var build = new SymbolicImageConstructionStep();
            bld.AddEdge(bld.Start, build);
            bld.AddEdge(build, bld.End);
            var b = new ParallelAction(new DumpGraphInfoAction(),
                                       new DumpGraphComponentsInfoAction(),
                                       new DumpMethodAction(),
                                       new GraphEntropyLogAction()
              );
            bld.AddEdge(build, b);
            var filterStart = new CopyContextKeysAction(FileKeys.WorkingFolderKey, FileKeys.LoggerKey);
            bld.AddEdge(bld.Start, filterStart);
            bld.AddEdge(filterStart, b);
          });

      IAction step = new ChainAction(
        new LoopAction("step", steps,
                       x => new BranchAction(
                              buildIS,
                              new AgregateAction(
                                bld =>
                                  {
                                    IAction xa1 = new ProxyAction(); 
                                    
                                    var xxx= new ReplaceContextAction(
                                       new SetMethod(
                                         new PointMethodSettings{Points=3, UseOverlapping = true, Overlap = .1}, 1L.Fill(dim)));
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
      gr.AddEdge(a4, step);
      gr.AddEdge(system, step);
      gr.AddEdge(method, step);


      var writeSequenceSlotAction = new WriteSequenceSlotAction();
      gr.AddEdge(step, writeSequenceSlotAction);
      gr.AddEdge(a5, writeSequenceSlotAction);
      gr.AddEdge(a5, new DumpSlotTimesAction(timeSlotKey));
      gr.AddEdge(a5, new DumpSlotTimesAction("BuildSI"));
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