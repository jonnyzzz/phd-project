using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
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

namespace DSIS.SimpleRunner
{
  public class Program
  {
    public static void Main()
    {      
      DefaultSystemSpace spIkedaCutted =
        new DefaultSystemSpace(2, new double[] { -1.1, -1.5 }, new double[] { 3.5, 1.8 }, new long[] { 3, 3 });
      DefaultSystemSpace sp =
        new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });      
      DefaultSystemSpace spD =
        new DefaultSystemSpace(2, new double[] { -2, -2 }, new double[] { 2, 2 }, new long[] { 2, 2 });      
      IAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(sp, 1.4), sp);
      IAction systemHenonD = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(sp, 1.272, 0.2), spD);
      IAction systemIked = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(sp), sp);
      IAction systemIkedaCut = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(spIkedaCutted, "Ikeda Cut"), spIkedaCutted);

      IAction wfBase = new WorkingFolderAction();

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

      StrangeEntropyEvaluatorParams[] entropys = {entropyFirst, /*entropySmartL, */entropySmart};
      IAction[] system = {/*systemHenon, */systemHenonD, /*systemIked, systemIkedaCut*/};

      SimpleParallel parallel = new SimpleParallel();
      for (int steps = 8; steps <= 15; steps++)
      {
        foreach (IAction action in system)
        {
          parallel.DoParallel(new ComputeDelegate(wfBase, steps, action, entropys).Do);          
        }        
      }
      parallel.WaitForEnd();
    }

    private class ComputeDelegate
    {
      private readonly IAction wfBase;
      private readonly int steps;
      private readonly IAction action;
      private readonly IEnumerable<StrangeEntropyEvaluatorParams> entropys;

      public void Do()
      {
        ComputeEntropy(wfBase, steps, action, entropys);
        Collect();
      }

      public ComputeDelegate(IAction wfBase, int steps, IAction action, IEnumerable<StrangeEntropyEvaluatorParams> entropys)
      {
        this.wfBase = wfBase;
        this.steps = steps;
        this.action = action;
        this.entropys = entropys;
      }
    }


    private static void Collect()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }

    private static void ComputeEntropy(IAction wfBase, int steps, IAction system,
                                       IEnumerable<StrangeEntropyEvaluatorParams> entropyMethod)
    {
      IAction a2 = new CreateCoordinateSystemAction();
      IAction a3 = new CreateInitialCellsAction();
      IAction a4 = new BuildSymbolicImageAction();
      IAction a5 = new ChainRecurrenctSimbolicImageAction();
      IAction method = new SetMethod(new BoxMethodSettings(0.1), new long[] {2, 2});

      ActionGraph gr = new ActionGraph();

      SystemWorkingFolderAction sysWf = new SystemWorkingFolderAction();
      CustomPrefixWorkingFolderAction wf = new CustomPrefixWorkingFolderAction(steps.ToString());
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

      AgregateAction buildIS = new AgregateAction(
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
                                                 
            Collect();
          });

      IAction step = new ChainAction(
        new LoopAction(steps - 1, buildIS),
        new ReplaceContextAction(new SetMethod(new PointMethodSettings(new int[] {2, 2}, 0.1), new long[] {2, 2})),
        buildIS
        );
               
      gr.AddEdge(wf, step);
      gr.AddEdge(logger, step);
      gr.AddEdge(a5, step);
      gr.AddEdge(system, step);
      gr.AddEdge(method, step);

      IAction draw = new DrawChainRecurrentAction();
      gr.AddEdge(step, draw);
      gr.AddEdge(wf, draw);
      gr.AddEdge(logger, draw);

      foreach (StrangeEntropyEvaluatorParams evaluatorParams in entropyMethod)
      {
        IAction customWf = new CustomPrefixWorkingFolderAction(evaluatorParams.PresentableName);

        IAction entropyParams = new SetStrangeEntropyParamsAction(evaluatorParams);
        IAction entropy = /*new ParallelAction(
          new ForeachStrongComponentAction(
          DrawEntropyAction(
            new StrangeEntropyAction())),*/
          DrawEntropyAction(new StrangeEntropyAction());

        gr.AddEdge(step, entropy);
        gr.AddEdge(wf, customWf);
        gr.AddEdge(customWf, entropy);
        gr.AddEdge(logger, entropy);
        gr.AddEdge(entropyParams, entropy);
      }

      gr.Execute();
    }
    
    private static IAction DrawEntropyAction(IAction entropy)
    {
      return new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
//            IAction a7 = new StrangeEntropyAction();
//            IAction a7 = new JVRMeasureAction();

            bld.AddEdge(bld.Start, new DumpGraphInfoAction());
            bld.AddEdge(bld.Start, new DumpGraphComponentsInfoAction());
            bld.AddEdge(bld.Start, entropy);

            IAction drawEntropy =
              new ParallelAction(
                new DumpEntropyParamsAction(),
                new DumpEntropyValueAction(),
                new DrawEntropyMeasure3dAction(),
                new DrawEntropyMeasure3dWithBaseAction(),
                new DrawEntropyMeasureColorMapAction()
                );
            ProxyAction pa = new ProxyAction();
            bld.AddEdge(bld.Start, pa);
            bld.AddEdge(pa, drawEntropy);
            bld.AddEdge(entropy, drawEntropy);

            bld.AddEdge(drawEntropy, bld.End);
          });
    }
  }
}