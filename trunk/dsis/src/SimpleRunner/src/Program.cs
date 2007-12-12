using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
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

namespace DSIS.SimpleRunner
{
  public class Program
  {
    public static void Main()
    {
      DefaultSystemSpace sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      DefaultSystemSpace spIkedaCutted =
        new DefaultSystemSpace(2, new double[] { -1.1, -1.5 }, new double[] { 3.5, 1.8 }, new long[] { 3, 3 });
      IAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(sp, 1.4), sp);
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

      StrangeEntropyEvaluatorParams[] entropys = {entropyFirst/*, entropySmartL, entropySmart*/};
      IAction[] system = {systemHenon/*, systemIked, systemIkedaCut*/};

      for (int steps = 12; steps <= 12; steps++)
      {
        foreach (IAction action in system)
        {
          ComputeEntropy(wfBase, steps, action, entropys);
        }        

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
      }
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

      IAction step = new LoopAction(steps, new AgregateAction(
                                             delegate(IActionGraphPartBuilder bld)
                                               {
                                                 SymbolicImageConstructionStep build =
                                                   new SymbolicImageConstructionStep();
                                                 bld.AddEdge(bld.Start, build);
                                                 bld.AddEdge(build, bld.End);
                                                 ParallelAction b = new ParallelAction(new DumpGraphInfoAction(),
                                                                                       new DumpGraphComponentsInfoAction
                                                                                         ());
                                                 ProxyAction p = new ProxyAction();
                                                 bld.AddEdge(build, b);
                                                 bld.AddEdge(bld.Start, p);
                                                 bld.AddEdge(p, b);
                                               }));

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

        IAction entropy = new ForeachStrongComponentAction(DrawEntropyAction());
        gr.AddEdge(step, entropy);
        gr.AddEdge(wf, customWf);
        gr.AddEdge(customWf, entropy);
        gr.AddEdge(logger, entropy);
        gr.AddEdge(entropyParams, entropy);
      }

      gr.Execute();
    }
    
    private static IAction DrawEntropyAction()
    {
      return new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            IAction a7 = new StrangeEntropyAction();

            bld.AddEdge(bld.Start, a7);

            IAction drawEntropy =
              new ProxiedChainAction(
                new DumpEntropyParamsAction(),
                new DumpEntropyValueAction(),
                new DrawEntropyMeasure3dAction(),
                new DrawEntropyMeasure3dWithBaseAction(),
                new DrawEntropyMeasureColorMapAction()
                );
            ProxyAction pa = new ProxyAction();
            bld.AddEdge(bld.Start, pa);
            bld.AddEdge(pa, drawEntropy);
            bld.AddEdge(a7, drawEntropy);

            bld.AddEdge(drawEntropy, bld.End);
          });
    }
  }
}