using System;
using System.Collections.Generic;
using System.IO;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Core.Util;
using DSIS.Core.Visualization;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Julia;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;

namespace DSIS.SimpleRunner
{
  public class Program
  {
    private const int STEPS = 11;
    private static string myWorkPath;
    private static string myHomePath;

    private static void Main()
    {
      string prePath = Path.GetDirectoryName(typeof (Program).Assembly.CodeBase);
      if (prePath.StartsWith("file:\\"))
        prePath = prePath.Substring("file:\\".Length);

      myHomePath = Path.GetFullPath(Path.Combine(prePath, @"..\..\..\..\"));
      myWorkPath = Path.GetFullPath(Path.Combine(myHomePath, @"results"));


//      Console.Out.WriteLine("Adaptive Method:");
//      MethodAndLog<IntegerCoordinateSystem, IntegerCoordinate>
//        (new BoxAdaptiveMethod<IntegerCoordinateSystem, IntegerCoordinate>(), 
//        BoxAdaptiveMethodSettings.Default);
//
      GC.Collect();
//
//      Console.Out.WriteLine("Box Method:");
//      MethodAndLog<IntegerCoordinateSystem, IntegerCoordinate>(
//        new BoxMethod<IntegerCoordinateSystem, IntegerCoordinate>(), 
//        BoxMethodSettings.Default);
//      
      GC.Collect();

      Console.Out.WriteLine("Adaptive Method:");
      MethodAndLog<IntegerCoordinateSystem2d, IntegerCoordinate2d>
        (new BoxAdaptiveMethod<IntegerCoordinateSystem2d, IntegerCoordinate2d>(), 
        BoxAdaptiveMethodSettings.Default);
//
//      GC.Collect();
//
//      Console.Out.WriteLine("Box Method:");
//      MethodAndLog<IntegerCoordinateSystem2d, IntegerCoordinate2d>(
//        new BoxMethod<IntegerCoordinateSystem2d, IntegerCoordinate2d>(), 
//        BoxMethodSettings.Default);
//      
      GC.Collect();

    }

    public static void MethodAndLog<T, Q>(ICellImageBuilder<Q> build, ICellImageBuilderSettings settings)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      using (TextWriter tw = File.CreateText(Path.Combine(myWorkPath, string.Format("{0}.{1}-log.txt", build.GetType().Name, typeof(Q).Name))))
      {
        DateTime now = DateTime.Now;
        tw.WriteLine("Started at {0}", now);

        DefaultSystemSpace sp = GetSystemSpace();
        T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(sp);

        DateTime finish = Method(ics, build, settings, tw);

        tw.WriteLine("Finished at {0}", finish);
        tw.WriteLine("Time spent {0} ms", (finish - now).TotalMilliseconds);
      }
    }

    public static DateTime Method<T, Q>(T cs, ICellImageBuilder<Q> build, ICellImageBuilderSettings settings, TextWriter tw)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      TarjanGraph<Q> graph = new TarjanGraph<Q>(cs);

      ICellCoordinateSystemConverter<Q, Q> conv = cs.Subdivide(new long[] {2, 2});
      CellProcessorContext<Q, Q> ctx =
        new CellProcessorContext<Q, Q>(
          cs.InitialSubdivision,
          conv,
          build,
          new CellImageBuilderContext<Q>(
            GetFunction(cs.SystemSpace),
            settings,
            conv.ToSystem, new GraphCellImageBuilder<Q>(graph)
            )
          );

      return DoConstruct<T, Q>(build, ctx, graph, tw);
    }

    private static ISystemInfo GetFunction(ISystemSpace sp)
    {
//      return new JuliaFuctionSystemInfoDecorator(sp);
//      return new IkedaFunctionSystemInfoDecorator(sp);
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

    private static DateTime DoConstruct<T, Q>(ICellImageBuilder<Q> boxMethod, CellProcessorContext<Q, Q> ctx, TarjanGraph<Q> graph, TextWriter tw)
      where Q : IIntegerCoordinate<Q>
      where T : IIntegerCoordinateSystem<Q>
    {
      SymbolicImageConstructionProcess<Q, Q> proc
        = new SymbolicImageConstructionProcess<Q, Q>();

      IGraphStrongComponents<Q> comps = null;
      for (int i = 0; i < STEPS; i++)
      {
        Console.Out.WriteLine("Step {0}", i + 1);
        Console.Out.WriteLine("Build:");
        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);
        
        Console.Out.WriteLine("Strong Components: ");
        
        comps = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        Console.Out.WriteLine("Done");
        int v = DumpAndGetCount(comps);

        IEnumerable<Q> cells = comps.GetCoordinates(comps.Components);
        graph = new TarjanGraph<Q>(ctx.Converter.ToSystem);

        ICellCoordinateSystemConverter<Q, Q> conv;
        conv = ctx.Converter.ToSystem.Subdivide(new long[] {2, 2});

        ctx =
          ctx.CreateNextContext(new CountEnumerable<Q>(cells, v), conv,
                                new GraphCellImageBuilder<Q>(graph));        
      }
      
      DateTime time = DateTime.Now;

      string gnuplotPath = Path.GetFullPath(Path.Combine(myHomePath, @"tools\gnuplot"));

      RenderToImage((T) ctx.Converter.ToSystem,
                    myWorkPath,
                    string.Format("{0}.{1}", boxMethod.GetType().Name, typeof(Q).Name), gnuplotPath, comps);

      ComputeEntropy(comps, graph, tw);

      return time;
    }

    private static void ComputeEntropy<Q>(IGraphStrongComponents<Q> comps, TarjanGraph<Q> graph, TextWriter tw)
      where Q : IIntegerCoordinate<Q>
    {
      Console.Out.WriteLine("Begin Entropy Computation");
      DateTime start = DateTime.Now;

      foreach (IStrongComponentInfo info in comps.Components)
      {
        tw.WriteLine("Component: nodes {0}", info.NodesCount);
      }
      
      double entropy = 
        EntropyEvaluator.GetEntropyEvaluator().ComputeEntropy(NullProgressInfo.INSTANCE, graph, comps);

      TimeSpan sp = DateTime.Now - start;
      Console.Out.WriteLine("Completed in {0} ms", sp.TotalMilliseconds);
      tw.WriteLine("Completed in {0} ms", sp.TotalMilliseconds);

      Console.Out.WriteLine("Entropy = {0}", entropy);
      tw.WriteLine("Entropy = {0}", entropy);
    }

    private static int DumpAndGetCount<Q>(IGraphStrongComponents<Q> cmops)
      where Q : IIntegerCoordinate<Q>
    {
      int v = 0;
      foreach (IStrongComponentInfo info in cmops.Components)
      {
        v += info.NodesCount;
      }

      Console.Out.WriteLine("v = {0}", v);
      return v;
    }


    private static void RenderToImage<T, Q>(T ics,
                                      string path, string title, string gnuplotPath,
                                      IGraphStrongComponents<Q> comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate<Q>
    {
      title = title.Replace("`", "_");

      Console.Out.WriteLine("Begin rendering...");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter> files =
        new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[3];

      foreach (INode<Q> node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          fw = new GnuplotPointsFileWriter(Path.Combine(path, title + "-" + ++components), ics.SystemSpace.Dimension);
          files[info] = fw;
        }
        ics.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      IGnuplotScriptGen gen = GnuplotSriptGen.ScriptGen(
        ics.SystemSpace.Dimension,
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