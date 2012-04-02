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

      Func<string, Action<IEnumerable<ImageColor>>> saver =
        name => pxls =>
                  {
                    var img = RenderProcessedImage(sys, pxls);
                    img.Save(Path.Combine(home, sys.Name + "." + name + ".png"), ImageFormat.Png);
                  };
                   
      var pixels = ImageToPixels(sys.Image, sys.GraphParameters).ToArray();
      saver("loaded")(pixels);

      var wg = new WithGraph(sys, logger);
      wg.OnGraphPixels = saver("graph");
      wg.OnInitialMeasurePixels = saver("jvr-init");
      wg.OnFinalMeasurePixels = saver("jvr-finish");
      graph.DoGeneric(wg);
    }

    private Image RenderProcessedImage(ImageEntropyData data, IEnumerable<ImageColor> pixels)
    {
      pixels = pixels.ToArray();

      var img = new Bitmap(data.Image.Width, data.Image.Height);
      double minValue = pixels.Min(x => x.Color);
      double maxValue = pixels.Max(x => x.Color);

      Color minColor = Color.Black;
      Color maxColor = Color.Red;

      Func<Color, double> R = c => c.R;
      Func<Color, double> G = c => c.G;
      Func<Color, double> B = c => c.B;
      Func<double, Func<Color, double>, int> y = 
        (x, F) => (int)((x - minValue)/(maxValue - minValue)*(F(maxColor) - F(minColor)) + F(minColor));

      var color =
        Math.Abs(minValue - maxValue) > 1e-8
          ? (Func<double, Color>) (d => Color.FromArgb(y(d, R), y(d, G), y(d, B)))
          : d => Color.Black;

      using (var g = Graphics.FromImage(img))
      {
        g.Clear(Color.White);
      }

      foreach (var p in pixels)
      {
        img.SetPixel(p.X, p.Y, color(p.Color));
      }

      return img;
    }



    private struct ImageColor
    {
      public int X;
      public int Y;
      public double Color;
    }

    private IEnumerable<ImageColor> ImageToPixels(Bitmap img, GraphFromImageBuilderParameters ps)
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
      private readonly ImageEntropyData myParameters;
      private readonly Logger myLogger;

      public Action<IEnumerable<ImageColor>> OnFinalMeasurePixels { get; set; }
      public Action<IEnumerable<ImageColor>> OnInitialMeasurePixels { get; set; }
      public Action<IEnumerable<ImageColor>> OnGraphPixels { get; set; } 

      public WithGraph(ImageEntropyData parameters, Logger logger)
      {
        myParameters = parameters;
        myLogger = logger;
      }

      public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph) 
        where TCell : ICellCoordinate 
        where TNode : class, INode<TCell>
      {
        myLogger.Write("Building string components...");
        var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
        myLogger.Write("Constructed {0} strong components: {1}", components.ComponentCount, String.Join(", ", components.Components.Select(x => x.NodesCount).OrderBy(x=>x).Take(5)) + "...");

        myLogger.Write("Rendering graph image...");
        RenderGraphComponents(components);

        myLogger.Write("Computing measure...");

        //TODO: foreach component 
        var jvrMeasureOptions = new JVRMeasureOptions
                                  {
                                    ExitCondition = JVRExitCondition.SummError, 
                                    IncludeSelfEdge = false, 
                                    EPS = 1e-4, 
                                    InitialWeight = new InitialMeasureOnGraph(myParameters)
                                  };

        var j = new LoggingJVRMeasure<TCell>(graph, components, jvrMeasureOptions, myLogger);
        myLogger.Write("Computing measure: contruction initial graph...");
        j.FillGraph();
        RenderMeasure(j.CreateEvaluator(), OnInitialMeasurePixels);

        myLogger.Write("Computing measure: Iterating over graph to compute measure...");
        j.Iterate(jvrMeasureOptions.EPS);
        myLogger.Write("Computing measure: Iterating over graph to compute measure: DOME...");
        
        var graphMeasure = j.CreateEvaluator();
        myLogger.Write("Measure computed: {0}", graphMeasure.GetEntropy());

        RenderMeasure(graphMeasure, OnFinalMeasurePixels);
      }

      private class LoggingJVRMeasure<TCell> : JVRMeasure<TCell> 
        where TCell : ICellCoordinate
      {
        private readonly Logger myLogger;
        private const int MAX_STEPS = 1300;
        private int myStep;
        public LoggingJVRMeasure(IReadonlyGraph<TCell> graph, IGraphStrongComponents<TCell> components, JVRMeasureOptions opts, Logger logger) : base(graph, components, opts)
        {
          myLogger = logger;
        }

        protected override bool CheckExitCondition(JVRExitCondition condition, double precision, double totalError, double qValue, double nodesChange, double edgesChange)
        {
          if (myStep++ > MAX_STEPS)
          {
            myLogger.Write("Limit of {0} iterations exceeded", MAX_STEPS);
            return true;
          }
          if (myStep % 10 == 0)
          {
            myLogger.Write(string.Format("  {5} -> precision:{0}, totalError:{1}, q:{2}, nodesChange:{3}, edgesChange:{4}",
            precision, totalError, qValue, nodesChange, edgesChange, myStep));
          }
          return base.CheckExitCondition(condition, precision, totalError, qValue, nodesChange, edgesChange);
        }
      }

      private class InitialMeasureOnGraph : IEntropyEdgeWeightCallback
      {
        private readonly ImageEntropyData myData;
        private readonly Func<Color, double> myFunc;

        public InitialMeasureOnGraph(ImageEntropyData data)
        {
          myData = data;
          myFunc = data.GraphParameters.Hash.Compile();
        }

        public string Name
        {
          get { return "From image"; }
        }

        public double EdgeWeight<T, Q>(Q system, JVRPair<T> edge, int index) 
          where T : ICellCoordinate 
          where Q : ICellCoordinateSystem<T>
        {
          var isys = (IIntegerCoordinateSystem) system;
          var c = new Cast {Point = edge.From};
          isys.DoGeneric(c);
          var px = myData.Image.GetPixel(c.Vector[0], c.Vector[1]);
          return myFunc(px);
        }

        private class Cast : IIntegerCoordinateSystemWith
        {
          public ICellCoordinate Point { get; set; }
          public int[] Vector { get; private set; }
          
          public void Do<T, Q>(T system)
            where T : IIntegerCoordinateSystem<Q>
            where Q : IIntegerCoordinate
          {
            var pt = (Q) Point;
            var t = new double[system.Dimension];
            system.TopLeftPoint(pt, t);
            Vector = t.Select(x => (int) x).ToArray();
          }
        }
      }

      private void RenderMeasure<TCell>(IGraphMeasure<TCell> graphMeasure, Action<IEnumerable<ImageColor>> action) 
        where TCell : ICellCoordinate
      {
        myLogger.Write("Rendering Measure image...");
        var conv = CreateCoordinatesConverter(graphMeasure);
        action(graphMeasure.GetMeasureNodes()
                          .Select(
                            x =>
                              {
                                var ccc = new double[2];
                                conv.Convert2(x.Key, ccc);
                                return new ImageColor
                                         {
                                           X = (int) ccc[0],
                                           Y = (int) ccc[1],
                                           Color = x.Value
                                         };
                              }));
      }

      private void RenderGraphComponents<TCell>(IGraphStrongComponents<TCell> components) 
        where TCell : ICellCoordinate        
      {
        var gconv = CreateCoordinatesConverter(components);
        OnGraphPixels(components
                        .GetCoordinates(components.Components)
                        .Select(x =>
                                  {
                                    var ccc = new double[2];
                                    gconv.Convert2(x, ccc);
                                    return new ImageColor
                                             {
                                               X = (int) ccc[0],
                                               Y = (int) ccc[1],
                                               Color = 0
                                             };
                                  }));
      }

      private static Converter<TCell> CreateCoordinatesConverter<TCell>(IGraphMeasure<TCell> graphMeasure)
        where TCell : ICellCoordinate  
      {
        var conv = new Converter<TCell>();
        ((IIntegerCoordinateSystem) graphMeasure.CoordinateSystem).DoGeneric(conv);
        return conv;
      }

      private static Converter<TCell> CreateCoordinatesConverter<TCell>(IGraphStrongComponents<TCell> graphMeasure)
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
      public Action<QQ, double[]> Convert2 { get; private set; }
      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Convert = (q, p) => system.CenterPoint((Q)(object) q, p);
        Convert2 = (q, p) => system.TopLeftPoint((Q)(object) q, p);
      }
    }
  }
}