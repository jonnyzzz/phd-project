using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Images;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  public abstract class ImageEntropyBuilderBase : ComputationBuilderBase<ImageEntropyData>
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    protected override void ComputeAll(ImageEntropyData sys)
    {
      string home = @"e:\\temp\\image-entropy2\\" + sys.Name + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");

      Directory.CreateDirectory(home);
      var wf = new WorkingFolderInfo(home);
      var logger = new AndLogger(new ConsoleLogger(), new FileLogger(wf));

      sys.Image.Save(Path.Combine(home, sys.Name + ".original.png"), ImageFormat.Png);
      sys.Serialize(logger);

      logger.Write("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      logger.Write("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);


      var data = IterateImage(sys.Image, sys.GraphParameters).ToDictionary(x=>x, x=>x.Color);
      EntropyDrawColorMapHelper.RenderMeasure(
        wf,
        data,
        (x, q) =>
          {
            q[0] = x.X;
            q[1] = x.Y;
          }, 
          sys.Name + ".remake.png", 
          "original image in selected color scale");

      graph.DoGeneric(new WithGraph(wf, logger, sys.Name));
    }


    private struct ImageColor
    {
      public int X;
      public int Y;
      public double Color;
    }

    private IEnumerable<ImageColor> IterateImage(Bitmap img, GraphFromImageBuilderParameters ps)
    {
      var expression = ps.Hash.Compile();
      for(int x = 0; x < img.Width; x++)
      {
        for(int y = 0; y < img.Height; y++)
        {
          yield return new ImageColor {X = x, Y = y, Color = expression(img.GetPixel(x, y))};
        }
      }
    }


    private class WithGraph : IReadonlyGraphWith
    {
      private readonly string myName;
      private readonly WorkingFolderInfo myWorkingFolder;
      private readonly Logger myLogger;

      public WithGraph(WorkingFolderInfo workingFolder, Logger logger, string name)
      {
        myWorkingFolder = workingFolder;
        myLogger = logger;
        myName = name;
      }

      public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph) 
        where TCell : ICellCoordinate 
        where TNode : class, INode<TCell>
      {
        myLogger.Write("Building string components...");
        var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
        myLogger.Write("Constructed {0} strong components: {1}", components.ComponentCount, String.Join(", ", components.Components.Select(x => x.NodesCount).OrderBy(x=>x).Take(5)) + "...");

        myLogger.Write("Computing measure...");

        //TODO: foreach component 
        var mes = new JVREvaluator<TCell>(new JVRMeasureOptions
                                            {
                                              ExitCondition = JVRExitCondition.MaxNodeError,
                                              IncludeSelfEdge = false,
                                              EPS = 1e-4,
                                              InitialWeight = EntropyLoopWeights.ONE,
                                            });
//        var mes = new LoggingJVREvaluator<TCell>(new JVRMeasureOptions(), myLogger);
        var graphMeasure = mes.Measure(graph, components);

        myLogger.Write("Measure computed: {0}", graphMeasure.GetEntropy());

        var conv = CreateCoordinatesConverter(graphMeasure);
        EntropyDrawColorMapHelper.RenderMeasure(myWorkingFolder, graphMeasure, conv.Convert, myName + ".dsis.png");
//        EntropyDraw3dHelper.RenderMeasure(myWorkingFolder, graphMeasure, conv.Convert);
      }

      private static Converter<TCell> CreateCoordinatesConverter<TCell>(IGraphMeasure<TCell> graphMeasure)
        where TCell : ICellCoordinate  
      {
        var conv = new Converter<TCell>();
        ((IIntegerCoordinateSystem) graphMeasure.CoordinateSystem).DoGeneric(conv);
        return conv;
      }
    }

    private class Converter<QQ> : IIntegerCoordinateSystemWith
    {
      public Action<QQ, double[]> Convert { get; private set; }
      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Convert = (q, p) => system.CenterPoint((Q)(object) q, p);
      }
    }
  }
}