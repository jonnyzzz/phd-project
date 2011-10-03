using System;
using System.Collections.Generic;
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
      Console.Out.WriteLine("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      Console.Out.WriteLine("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);

      graph.DoGeneric(new WithGraph());
    }

    private class WithGraph : IReadonlyGraphWith
    {
      public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph) 
        where TCell : ICellCoordinate 
        where TNode : class, INode<TCell>
      {
        Console.Out.WriteLine("Building string components...");
        var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
        Console.Out.WriteLine("Constructed {0} strong components: {1}", components.ComponentCount, String.Join(", ", components.Components.Select(x => x.NodesCount)));


        Console.Out.WriteLine("Computing measure...");

        //TODO: foreach component 
        var mes = new LoggingJVREvaluator<TCell>(new JVRMeasureOptions(), new ConsoleLogger());
        var graphMeasure = mes.Measure(graph, components);

        Console.Out.WriteLine("Measure computed: {0}", graphMeasure.GetEntropy());

        var home = @"e:\\temp\\image-entropy\\" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
        Directory.CreateDirectory(home);

        var conv = new Converter<TCell>();
        ((IIntegerCoordinateSystem)graphMeasure.CoordinateSystem).DoGeneric(conv);

        EntropyDrawColorMapHelper.RenderMeasure(new WorkingFolderInfo(home), graphMeasure, conv.Convert);
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