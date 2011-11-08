using System;
using System.IO;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Graph.Entropy.Impl.JVR;
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
      string home = @"e:\\temp\\image-entropy\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + "\\" + sys.Name;

      Directory.CreateDirectory(home);
      var wf = new WorkingFolderInfo(home);
      var logger = new AndLogger(new ConsoleLogger(), new FileLogger(wf));

      sys.Serialize(logger);

      logger.Write("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      logger.Write("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);

      graph.DoGeneric(new WithGraph(wf, logger));
    }

    private class WithGraph : IReadonlyGraphWith
    {
      private readonly WorkingFolderInfo myWorkingFolder;
      private readonly Logger myLogger;

      public WithGraph(WorkingFolderInfo workingFolder, Logger logger)
      {
        myWorkingFolder = workingFolder;
        myLogger = logger;
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
        var mes = new LoggingJVREvaluator<TCell>(new JVRMeasureOptions(), myLogger);
        var graphMeasure = mes.Measure(graph, components);

        myLogger.Write("Measure computed: {0}", graphMeasure.GetEntropy());

        var conv = new Converter<TCell>();
        ((IIntegerCoordinateSystem)graphMeasure.CoordinateSystem).DoGeneric(conv);

//        EntropyDrawColorMapHelper.RenderMeasure(myWorkingFolder, graphMeasure, conv.Convert);
        EntropyDraw3dHelper.RenderMeasure(myWorkingFolder, graphMeasure, conv.Convert);
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