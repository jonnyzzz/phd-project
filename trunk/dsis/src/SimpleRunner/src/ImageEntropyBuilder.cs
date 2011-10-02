using System;
using System.Collections.Generic;
using System.Drawing;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Images;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;
using DSIS.Graph.Abstract.Algorithms;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public class ImageEntropyData : BuilderData, ICloneable<ImageEntropyData>
  {
    public Bitmap Image { get; set; }

    public GraphFromImageBuilderParameters GraphParameters { get; set; }

    public ImageEntropyData Clone()
    {
      var imageEntropyData = new ImageEntropyData{ Image = Image, GraphParameters = GraphParameters};
      imageEntropyData.CopyState(this);
      return imageEntropyData;
    }
  }

  [ComponentImplementation]
  public class ImageEntropyBuilder : ComputationBuilderBase<ImageEntropyData>
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    protected override IEnumerable<IEnumerable<ImageEntropyData>> GetSystemsToRun2()
    {
      var bmp = new Bitmap(100,100);

      yield return new ImageEntropyData{Image = bmp}.Enum();      
    }

    protected override void ComputeAll(ImageEntropyData sys)
    {
      Console.Out.WriteLine("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      Console.Out.WriteLine("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);

      graph.DoGeneric(new WithGraph());
    }

    private class WithGraph : IReadonlyGraphWith
    {
      public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph) where TCell : ICellCoordinate where TNode : class, INode<TCell>
      {
        Console.Out.WriteLine("Building string components...");
        var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
        Console.Out.WriteLine("Constructed {0} strong components: {1}", components.ComponentCount, String.Join(", ", components.Components.Select(x => x.NodesCount)));


        Console.Out.WriteLine("Computing measure...");
        var mes = new LoggingJVREvaluator<TCell>(new JVRMeasureOptions(), new ConsoleLogger());
        var graphMeasure = mes.Measure(graph, components);

        Console.Out.WriteLine("Measure computed: {0}", graphMeasure.GetEntropy());
        foreach (var m in graphMeasure.Measure)
        {
          Console.Out.WriteLine("Component: {0}", m.Second);
        }
      }
    }
  }
}