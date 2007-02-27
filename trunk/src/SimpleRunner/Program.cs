using System;
using System.Collections.Generic;
using System.IO;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Core.Visualization;
using DSIS.Function.Predefined.Henon;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.src.Adapter;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  internal class Program
  {
    private static string myWorkPath;
    private static string myHomePath;

    private const int STEPS = 13;

    private static void Main()
    {
      string prePath = Path.GetDirectoryName(typeof (Program).Assembly.CodeBase);
      if (prePath.StartsWith("file:\\"))
        prePath = prePath.Substring("file:\\".Length);

      myHomePath = Path.GetFullPath(Path.Combine(prePath, @"..\..\..\..\"));
      myWorkPath = Path.GetFullPath(Path.Combine(myHomePath, @"results"));


//      Console.Out.WriteLine("Adaptive Method:");
//      MethodAndLog(new BoxAdaptiveMethod(), BoxAdaptiveMethodSettings.Default);
      Console.Out.WriteLine("Box Method:");
      MethodAndLog(new BoxMethod(), BoxMethodSettings.Default);      
    }

    public static void MethodAndLog(ICellImageBuilder<IntegerCoordinate> build, ICellImageBuilderSettings settings)
    {
      using (TextWriter tw = File.CreateText(Path.Combine(myWorkPath, build.GetType().Name + "-log.txt")))
      {
        DateTime now = DateTime.Now;
        tw.WriteLine("Started at {0}", now);

        DateTime finish = Method(build, settings);

        tw.WriteLine("Finished at {0}", finish);
        tw.WriteLine("Time spent {0} ms", (finish - now).TotalMilliseconds);
      }
    }

    public static DateTime Method(ICellImageBuilder<IntegerCoordinate> build, ICellImageBuilderSettings settings)
    {
      DefaultSystemSpace sp = GetSystemSpace();
      IntegerCoordinateSystem cs = new IntegerCoordinateSystem(sp);

      TarjanGraph<IntegerCoordinate> graph = new TarjanGraph<IntegerCoordinate>(cs);

      ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> conv = cs.Subdivide(new long[] {3,3});
      CellProcessorContext<IntegerCoordinate, IntegerCoordinate> ctx =
        new CellProcessorContext<IntegerCoordinate, IntegerCoordinate>(          
          cs.InitialSubdivision,
          conv,
          build,
          new CellImageBuilderContext<IntegerCoordinate>(
            GetFunction(sp),
            settings,
            conv.ToSystem, new GraphCellImageBuilder<IntegerCoordinate>(graph)
            )
          );

      return DoConstruct(build, ctx, graph);
    }

    private static ISystemInfo GetFunction(DefaultSystemSpace sp)
    {
      return new HenonFunctionSystemInfoDecorator(sp, 1.4);
//      return new DelayedFunctionSystemInfo(sp, 2.27);
      //return new FoodChainSystemInfo(sp);
    }

    private static DefaultSystemSpace GetSystemSpace()
    {
      return new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {10, 10});
//      return new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {2, 2});
      //return new DefaultSystemSpace(3, new double[] {0.001, 0.001, 0.001}, new double[] {10, 10, 10}, new long[] {2, 2, 2});
    }

    private static DateTime DoConstruct(ICellImageBuilder<IntegerCoordinate> boxMethod,
                                    CellProcessorContext<IntegerCoordinate, IntegerCoordinate> ctx,
                                    TarjanGraph<IntegerCoordinate> graph)
    {
      SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate> proc
        = new SymbolicImageConstructionProcess<IntegerCoordinate, IntegerCoordinate>();
        
      proc.Bind(ctx);

      proc.Execute(NullProgressInfo.INSTANCE);

      for (int i = 0; i < STEPS; i++)
      {
        Console.Out.WriteLine("Strong Components: ");

        IGraphStrongComponents<IntegerCoordinate> cmops
          = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        Console.Out.WriteLine("Done");
        int v = DumpAndGetCount(cmops);

        IEnumerable<IntegerCoordinate> cells = cmops.GetCoordinates(cmops.Components);
        graph = new TarjanGraph<IntegerCoordinate>(ctx.Converter.ToSystem);

        ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> conv;
        conv = ctx.Converter.ToSystem.Subdivide(new long[] {2,2});

        ctx =
          ctx.CreateNextContext(new CountEnumerable<IntegerCoordinate>(cells, v), conv,
                                new GraphCellImageBuilder<IntegerCoordinate>(graph));
        proc.Bind(ctx);

        Console.Out.WriteLine("Image");
        proc.Execute(NullProgressInfo.INSTANCE);
        Console.Out.WriteLine("Done");
      }

      IGraphStrongComponents<IntegerCoordinate> comps = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      DumpAndGetCount(comps);

      DateTime time = DateTime.Now;

      string gnuplotPath = Path.GetFullPath(Path.Combine(myHomePath, @"tools\gnuplot"));

      RenderToImage((IntegerCoordinateSystem) ctx.Converter.ToSystem,
                    myWorkPath,
                    boxMethod.GetType().Name, gnuplotPath, comps);

      return time;
    }

    private static int DumpAndGetCount(IGraphStrongComponents<IntegerCoordinate> cmops)
    {
      int v = 0;
      foreach (IStrongComponentInfo info in cmops.Components)
      {
        v += info.NodesCount;
      }

      Console.Out.WriteLine("v = {0}", v);
      return v;
    }


    private static void RenderToImage(IntegerCoordinateSystem ics,
                                      string path, string title, string gnuplotPath,
                                      IGraphStrongComponents<IntegerCoordinate> comps)
    {
      Console.Out.WriteLine("Begin rendering...");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter> files =
        new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[3];

      foreach (INode<IntegerCoordinate> node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          fw = new GnuplotPointsFileWriter(Path.Combine(path, title + "-" + ++components), ics.Dimension);
          files[info] = fw;
        }
        ics.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      IGnuplotScriptGen gen = GnuplotSriptGen.ScriptGen(
        ics.Dimension, 
        Path.Combine(path, title + "-script.gnuplot"),
        new GnuplotScriptParameters(Path.Combine(path, title + "-picture.png"), title));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Dispose();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer(gnuplotPath);
      drw.DrawImage(gen);
    }
  }
}