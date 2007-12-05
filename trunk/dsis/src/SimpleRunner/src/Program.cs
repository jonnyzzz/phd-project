using DSIS.CellImageBuilder.BoxMethod;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
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
      ActionGraph gr = new ActionGraph();

      DefaultSystemSpace sp = new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });

//      IAction system = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(sp, 1.4), sp);
      IAction system = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(sp), sp);
      
      IAction a2 = new CreateCoordinateSystemAction();
      IAction a3 = new CreateInitialCellsAction();      
      IAction a4 = new BuildSymbolicImageAction();
      IAction a5 = new ChainRecurrenctSimbolicImageAction();
      IAction method = new SetMethod(new BoxMethodSettings(0.1), new long[] { 2, 2 });

      gr.AddEdge(system, a2);
      gr.AddEdge(a2, a3);
      gr.AddEdge(a3, a4);
      gr.AddEdge(system, a4);
      
      gr.AddEdge(method, a4);
      gr.AddEdge(a4, a5);
      gr.AddEdge(a4, new DumpGraphInfoAction());
      gr.AddEdge(a5, new DumpGraphComponentsInfoAction());

      IAction step = new LoopAction(10,new AgregateAction(
        delegate(IActionGraphPartBuilder bld)
          {
            SymbolicImageConstructionStep build = new SymbolicImageConstructionStep();
            bld.AddEdge(build, new DumpGraphInfoAction());
            bld.AddEdge(build, new DumpGraphComponentsInfoAction());
            bld.AddEdge(bld.Start, build);
            bld.AddEdge(build, bld.End);
          }));

      gr.AddEdge(a5, step);
      gr.AddEdge(system, step);     
      gr.AddEdge(method, step);

      IAction wf = new WorkingFolderAction();

      IAction draw = new DrawChainRecurrentAction();
      gr.AddEdge(step, draw);
      gr.AddEdge(wf, draw);
 
      IAction a6 = new UpdateContextAction(delegate(Context input, Context cx)
                                             {
                                               Keys.StrangeEntropyEvaluatorParams.Set(cx,
                                                                                      new StrangeEntropyEvaluatorParams(
                                                                                        StrangeEvaluatorType.WeightSearch_2,
                                                                                        StrangeEvaluatorStrategy.SMART,
                                                                                        EntropyLoopWeights.CONST));
                                             });

      IAction a7 = new StrangeEntropyAction();

      gr.AddEdge(a6, a7);
      gr.AddEdge(step, a7);      
      gr.AddEdge(a7, new DumpEntropyValueAction());

      
      IAction drawEntropy = new DrawEntropyMeasure3dAction();
      IAction drawEntropy3 = new DrawEntropyMeasure3dWithBaseAction();
      IAction drawEntropy2 = new DrawEntropyMeasureColorMapAction();

      gr.AddEdge(wf, drawEntropy);
      gr.AddEdge(wf, drawEntropy2);      
      gr.AddEdge(wf, drawEntropy3);      
      gr.AddEdge(a7, drawEntropy);
      gr.AddEdge(a7, drawEntropy2);
      gr.AddEdge(a7, drawEntropy3);
      gr.AddEdge(step, drawEntropy);
      gr.AddEdge(step, drawEntropy2);
      gr.AddEdge(step, drawEntropy3);

      gr.AddEdge(wf, new DumpWorkingFolderAction());
      gr.Execute();
    }

  }
}