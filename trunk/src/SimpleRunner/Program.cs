using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder;
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
  enum EMPTY {}

  class Program
  {
    static void Main()
    {
      DefaultSystemSpace sp = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[]{ 10,10}, new long[] {2,2});
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sp);

      TarjanGraph<IntegerCoordinate, EMPTY> graph = new TarjanGraph<IntegerCoordinate, EMPTY>(cs);
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
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate, EMPTY>(graph)
            )
        );

      SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate> proc 
        = new SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate>();

      proc.Bind(ctx);

      proc.Execute(NullProgressInfo.INSTANCE);

      for (int i = 0; i < 2; i++)
      {
        IGraphStrongComponents<IntegerCoordinate, EMPTY> cmops
          = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        long v = 0;
        foreach (IStrongComponentInfo info in cmops.Components)
        {
          v += info.NodesCount;
        }

        Console.Out.WriteLine("v = {0}", v);

        IEnumerable<IntegerCoordinate> cells = cmops.GetCoordinates(cmops.Components);
        graph = new TarjanGraph<IntegerCoordinate, EMPTY>(ctx.Converter.ToSystem);

        conv = ctx.Converter.ToSystem.Subdivide(new long[] {3, 3});
        ctx = new CellProcessorContext<IntegerCoordinate, IntegerCoordinate>(
          v,
          cells,
          conv,
          boxMethod,
          new CellImageBuilderContext<IntegerCoordinate>(
            new HenonFunctionSystemInfoDecorator(sp, 1.4),
            BoxMethodParameters.DefaultBoxMethodParameters,
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate, EMPTY>(graph)
            )
          );

        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);
      }

      graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
    }
  }
}
