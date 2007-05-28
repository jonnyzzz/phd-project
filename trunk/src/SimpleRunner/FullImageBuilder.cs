using System;
using System.Collections.Generic;
using System.IO;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.AdaptiveMethod;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilder<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly string myRootPath;
    private readonly int mySteps;
    private readonly string myHomePath;

    protected abstract ISystemSpace CreateSystemSpace();
    protected abstract ISystemInfo CreateSystemFunction(ISystemSpace space);

    protected FullImageBuilder(string homePath, string rootPath, int steps)
    {
      myHomePath = homePath;
      mySteps = steps;
      DateTime now = DateTime.Now;      
      myRootPath = Path.Combine(rootPath, string.Format("{0}-{1}-{2} {3}-{4}", now.Year, now.Month, now.Day, now.Hour, now.Minute));

      if (Directory.Exists(myRootPath))
      {
        Directory.Delete(myRootPath, true);
      }
      Directory.CreateDirectory(myRootPath);
    }

    public void ComputeAllMethods()
    {
      using (TextWriter log = File.CreateText(Path.Combine(myRootPath, "log.txt")))
      {
        Console.Out.WriteLine("Adaptive Method:");
        log.WriteLine("Adaptive Method:");
        MethodAndLog
          (string.Empty,
           new AdaptiveMethod<T, Q>(), AdaptiveMethodSettings.DEFAULT);

        GC.Collect();

        Console.Out.WriteLine("Point Method:");
        MethodAndLog
          ("Point",
           new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3}));

        GC.Collect();

        Console.Out.WriteLine("Overlaping Point Method:");
        log.WriteLine("Overlaping Point Method:");
        MethodAndLog
          ("Overlaping",
           new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3}, 0.1));

        GC.Collect();

        Console.Out.WriteLine("Box Method:");
        log.WriteLine("Box Method:");
        MethodAndLog(
          string.Empty,
          new BoxMethod<T, Q>(), BoxMethodSettings.Default);

        GC.Collect();
      }
    }

    protected void MethodAndLog(string title, ICellImageBuilder<Q> build, ICellImageBuilderSettings settings)
    {
      string dir = Path.Combine(myRootPath, string.Format("{0}.{1}.{2}", title, build.GetType().Name, typeof (Q).Name));
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      using (TextWriter logWriter = File.CreateText(Path.Combine(dir, "log.txt")))
      {
        DateTime now = DateTime.Now;
        logWriter.WriteLine("Started at {0}", now);
        Console.Out.WriteLine("Started at {0}", now);

        ISystemSpace sp = CreateSystemSpace();
        T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T, Q>(sp);

        DateTime finish = Method(ics, build, settings, logWriter, dir);

        logWriter.WriteLine("Finished at {0}", finish);
        Console.Out.WriteLine("Finished at {0}", finish);
        logWriter.WriteLine("Time spent {0} ms", (finish - now).TotalMilliseconds);
        Console.Out.WriteLine("Time spent {0} ms", (finish - now).TotalMilliseconds);
      }
    }

    public DateTime Method(T cs, ICellImageBuilder<Q> build, ICellImageBuilderSettings settings, TextWriter tw, string dir)
    {
      TarjanGraph<Q> graph = new TarjanGraph<Q>(cs);

      ICellCoordinateSystemConverter<Q, Q> conv = cs.Subdivide(new long[] { 2, 2 });
      CellProcessorContext<Q, Q> ctx =
        new CellProcessorContext<Q, Q>(
          cs.InitialSubdivision,
          conv,
          build,
          new CellImageBuilderContext<Q>(
            CreateSystemFunction(cs.SystemSpace),
            settings,
            conv.ToSystem, new GraphCellImageBuilder<Q>(graph)
            )
          );

      return DoConstruct(build, ctx, graph, tw, dir);
    }

    private DateTime DoConstruct(ICellImageBuilder<Q> boxMethod, 
                                 CellProcessorContext<Q, Q> ctx, TarjanGraph<Q> graph, 
                                 TextWriter logWriter, string dir)
    {
      SymbolicImageConstructionProcess<Q, Q> proc = new SymbolicImageConstructionProcess<Q, Q>();

      IGraphStrongComponents<Q> comps = null;
      for (int i = 0; i < mySteps; i++)
      {
        logWriter.WriteLine("Step {0}", i + 1);
        Console.Out.WriteLine("Step {0}", i + 1);
        logWriter.WriteLine("Build:");
        Console.Out.WriteLine("Build:");
        proc.Bind(ctx);
        proc.Execute(NullProgressInfo.INSTANCE);

        logWriter.WriteLine("Strong Components: ");
        Console.Out.WriteLine("Strong Components: ");
        comps = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

        logWriter.WriteLine("Done");
        Console.Out.WriteLine("Done");
        int v = DumpAndGetCount(comps, logWriter);

        IEnumerable<Q> cells = comps.GetCoordinates(comps.Components);
        graph = new TarjanGraph<Q>(ctx.Converter.ToSystem);

        ICellCoordinateSystemConverter<Q, Q> conv;
        conv = ctx.Converter.ToSystem.Subdivide(new long[] { 2, 2 });

        ctx = ctx.CreateNextContext(new CountEnumerable<Q>(cells, v), conv, new GraphCellImageBuilder<Q>(graph));
      }

      DateTime time = DateTime.Now;

      string gnuplotPath = Path.GetFullPath(Path.Combine(myHomePath, @"tools\gnuplot"));

      RenderToImage((T)ctx.Converter.ToSystem,
                    dir,
                    string.Format("{0}.{1}", boxMethod.GetType().Name, typeof(Q).Name), 
                    gnuplotPath, comps,
                    logWriter);

      ComputeEntropy(comps, graph, logWriter, dir);

      return time;
    }

    private static int DumpAndGetCount<Q>(IGraphStrongComponents<Q> cmops, TextWriter log)
      where Q : IIntegerCoordinate<Q>
    {
      int v = 0;
      foreach (IStrongComponentInfo info in cmops.Components)
      {
        v += info.NodesCount;
      }

      Console.Out.WriteLine("v = {0}", v);
      log.WriteLine("v = {0}", v);
      return v;
    }


    private static void RenderToImage(T ics, string path, string title, string gnuplotPath,                
                                  IGraphStrongComponents<Q> comps, TextWriter log)
    {
      title = title.Replace("`", "_");

      log.WriteLine("Begin rendering...");
      Console.Out.WriteLine("Begin rendering...");

      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter> files =
        new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[ics.SystemSpace.Dimension];

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

    private static void ComputeEntropy(IGraphStrongComponents<Q> comps, IGraph<Q> graph, TextWriter log, string dir)
    {
      using (TextWriter ent = File.CreateText(Path.Combine(dir, "Entropy.txt")))
      {
        log.WriteLine("Begin Entropy Computation");
        Console.Out.WriteLine("Begin Entropy Computation");
        DateTime start = DateTime.Now;

        foreach (IStrongComponentInfo info in comps.Components)
        {
          Console.Out.WriteLine("Component: nodes {0}", info.NodesCount);
          log.WriteLine("Component: nodes {0}", info.NodesCount);
          ent.WriteLine("Component: nodes {0}", info.NodesCount);
        }
        log.WriteLine();
        ent.WriteLine();

        double entropy = EntropyEvaluator.GetLoopEntropyEvaluator().
          ComputeEntropy(NullProgressInfo.INSTANCE, graph, comps);

        TimeSpan sp = DateTime.Now - start;
        log.WriteLine("Completed in {0} ms", sp.TotalMilliseconds);
        ent.WriteLine("Completed in {0} ms", sp.TotalMilliseconds);
        Console.Out.WriteLine("Completed in {0} ms", sp.TotalMilliseconds);

        log.WriteLine("Entropy = {0}", entropy);
        ent.WriteLine("Entropy = {0}", entropy);
        Console.Out.WriteLine("Entropy = {0}", entropy);
      }
    }
  }
}