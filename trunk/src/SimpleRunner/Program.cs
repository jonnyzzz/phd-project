using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Function.Predefined.Henon;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.src.Adapter;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  class Program
  {
    static void Main()
    {
      Console.Out.WriteLine("Adaptive Method:");
      MainBoxAdaptiveMethod();
      Console.Out.WriteLine("Box Method:");
      //MainBoxMethod();
    }

    public static void MainBoxMethod()
    {
      DefaultSystemSpace sp = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[]{ 10,10}, new long[] {2,2});
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sp);

      TarjanGraph<IntegerCoordinate> graph = new TarjanGraph<IntegerCoordinate>(cs);
      BoxMethod boxMethod = new BoxMethod();

      ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> conv = cs.Subdivide(new long[]{3,3});
      CellProcessorContext<IntegerCoordinate, IntegerCoordinate> ctx = 
        new CellProcessorContext<IntegerCoordinate, IntegerCoordinate>(
        cs.InitialCellsCount,
        cs.InitialSebdivision,
        conv,
        boxMethod,
        new CellImageBuilderContext<IntegerCoordinate>(
            new HenonFunctionSystemInfoDecorator(sp, 1.4),
            BoxMethodParameters.DefaultBoxMethodParameters,
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate>(graph)
            )
        );

      DoConstruct(boxMethod, ctx, graph, sp);
    }

    public static void MainBoxAdaptiveMethod()
    {
      DefaultSystemSpace sp = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[]{ 10,10}, new long[] {2,2});
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sp);

      TarjanGraph<IntegerCoordinate> graph = new TarjanGraph<IntegerCoordinate>(cs);
      BoxAdaptiveMethod boxMethod = new BoxAdaptiveMethod();

      ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> conv = cs.Subdivide(new long[]{3,3});
      CellProcessorContext<IntegerCoordinate, IntegerCoordinate> ctx = 
        new CellProcessorContext<IntegerCoordinate, IntegerCoordinate>(
        cs.InitialCellsCount,
        cs.InitialSebdivision,
        conv,
        boxMethod,
        new CellImageBuilderContext<IntegerCoordinate>(
            new HenonFunctionSystemInfoDecorator(sp, 1.4),
            BoxAdaptiveMethodSettings.Default,
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate>(graph)
            )
        );

      DoConstruct(boxMethod, ctx, graph, sp);
    }

    private static void DoConstruct(ICellImageBuilder<IntegerCoordinate> boxMethod, 
      CellProcessorContext<IntegerCoordinate, IntegerCoordinate> ctx, 
      TarjanGraph<IntegerCoordinate> graph, DefaultSystemSpace sp)
    {
      SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate> proc 
        = new SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate>();

      proc.Bind(ctx);

      proc.Execute(NullProgressInfo.INSTANCE);

      for (int i = 0; i < 3; i++)
      {
        IGraphStrongComponents<IntegerCoordinate> cmops
          = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        long v = DumpAndGetCount(cmops);

        IEnumerable<IntegerCoordinate> cells = cmops.GetCoordinates(cmops.Components);
        graph = new TarjanGraph<IntegerCoordinate>(ctx.Converter.ToSystem);

        ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> conv;
        conv = ctx.Converter.ToSystem.Subdivide(new long[] {3, 3});
        ctx = new CellProcessorContext<IntegerCoordinate, IntegerCoordinate>(
          v,
          cells,
          conv,
          boxMethod,
          new CellImageBuilderContext<IntegerCoordinate>(
            new HenonFunctionSystemInfoDecorator(sp, 1.4),
            ctx.CellImageBuilderContext.Settings,
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate>(graph)
            )
          );

        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);
      }
      
      DumpAndGetCount(graph.ComputeStrongComponents(NullProgressInfo.INSTANCE));
    }

    private static long DumpAndGetCount(IGraphStrongComponents<IntegerCoordinate> cmops)
    {
      long v = 0;
      foreach (IStrongComponentInfo info in cmops.Components)
      {
        v += info.NodesCount;
      }

      Console.Out.WriteLine("v = {0}", v);
      return v;
    }
  }
}
