using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme.Impl.Actions.Files;
using JetBrains.Annotations;

namespace DSIS.SimpleRunner.ImageEntropy
{
  internal abstract class ComputeImageMeasureActionBase : IReadonlyGraphWith
  {
    protected readonly Logger myLogger;

    public Action<IEnumerable<ImageColor>> OnGraphPixels { get; set; }

    public ComputeImageMeasureActionBase([NotNull] Logger logger)
    {
      myLogger = logger;
      OnGraphPixels = _ => { };
    }

    public void Apply(IReadonlyGraph graph)
    {
      graph.DoGeneric(this);
    }

    public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>
    {
      myLogger.Write("Building string components...");
      var components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      myLogger.Write("Constructed {0} strong components: {1}", components.ComponentCount,
                     String.Join(", ", components.Components.Select(x => x.NodesCount).OrderBy(x => x).Take(5)) +
                     "...");

      myLogger.Write("Rendering graph image...");
      RenderGraphComponents(components);

      myLogger.Write("Computing measure...");

      //TODO: foreach component 
      var jvrMeasureOptions = new JVRMeasureOptions
        {
          ExitCondition = JVRExitCondition.SummError,
          IncludeSelfEdge = false,
          EPS = 1e-8,
          InitialWeight = CreateInitialWeightCallback()
        };

      var setup = SetupIterateMeasure<TCell, TNode>(jvrMeasureOptions);
      var j = new LoggingJVRMeasure<TCell>(graph, components, jvrMeasureOptions, myLogger);
      setup(j);

      myLogger.Write("Computing measure: contruction initial graph...");
      j.FillGraph();

      IterateMeasure<TCell, TNode>(j, jvrMeasureOptions);
    }

    protected abstract IEntropyEdgeWeightCallback CreateInitialWeightCallback();

    protected virtual Action<LoggingJVRMeasure<TCell>> SetupIterateMeasure<TCell, TNode>(JVRMeasureOptions jvrMeasureOptions)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>
    {
      return j => { };
    }

    protected abstract void IterateMeasure<TCell, TNode>(LoggingJVRMeasure<TCell> j, JVRMeasureOptions jvrMeasureOptions)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>;

    protected void RenderMeasure<TCell>(IGraphMeasure<TCell> graphMeasure, Action<IEnumerable<ImageColor>> action)
      where TCell : ICellCoordinate
    {
      myLogger.Write("Rendering Measure image...");
      var conv = CoordinateConverter<TCell>.CreateCoordinatesConverter(graphMeasure);
      action(graphMeasure.GetMeasureNodes().Select(x => conv.Convert3(x.Key, x.Value)));
    }

    protected void RenderGraphComponents<TCell>(IGraphStrongComponents<TCell> components)
      where TCell : ICellCoordinate
    {
      var gconv = CoordinateConverter<TCell>.CreateCoordinatesConverter(components);
      var pixels = components.GetCoordinates(components.Components).Select(x => gconv.Convert3(x, 0)).ToArray();
      var norm = pixels.Sum(x => x.Color);
      OnGraphPixels(pixels.Select(x => x.Norm(norm)));
    }

    protected void LogComputedMeasures<TCell>(IGraphMeasure<TCell> finalMeasure, IGraphMeasure<TCell> initialMeasure)
      where TCell : ICellCoordinate
    {
      myLogger.Write("Measure computed (Osipenko): {0}", finalMeasure.GetEntropy());
      myLogger.Write("Measure computed (Relative): {0}", finalMeasure.ComputeRelativeEntropy(initialMeasure));
    }
  }
}