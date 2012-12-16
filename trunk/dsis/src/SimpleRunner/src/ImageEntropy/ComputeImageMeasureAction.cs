using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.imageEntropy
{
  internal class ComputeImageMeasureAction : IReadonlyGraphWith
  {
    private readonly ImageEntropyData myParameters;
    private readonly Logger myLogger;

    public Action<IEnumerable<ImageColor>> OnFinalMeasurePixels { get; set; }
    public Action<IEnumerable<ImageColor>> OnInitialMeasurePixels { get; set; }
    public Action<IEnumerable<ImageColor>> OnGraphPixels { get; set; }

    public ComputeImageMeasureAction(ImageEntropyData parameters, Logger logger)
    {
      myParameters = parameters;
      myLogger = logger;

      OnFinalMeasurePixels = _ => { };
      OnInitialMeasurePixels = _ => { };
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
                                  EPS = myParameters.MeasurePrecision ?? 1e-8,
                                  InitialWeight = new InitialMeasureOnGraph(myParameters)
                                };

      var j = new LoggingJVRMeasure<TCell>(myParameters, graph, components, jvrMeasureOptions, myLogger);
      myLogger.Write("Computing measure: contruction initial graph...");
      j.FillGraph();
      var initialMeasure = j.CreateEvaluatorCopy();
      RenderMeasure(initialMeasure, OnInitialMeasurePixels);

      myLogger.Write("Computing measure: Iterating over graph to compute measure...");
      j.Iterate(jvrMeasureOptions.EPS);
      myLogger.Write("Computing measure: Iterating over graph to compute measure: DOME...");

      var finalMeasure = j.CreateEvaluatorCopy();
      myLogger.Write("Measure computed (Osipenko): {0}", finalMeasure.GetEntropy());
      myLogger.Write("Measure computed (Relative): {0}", finalMeasure.ComputeRelativeEntropy(initialMeasure));

      RenderMeasure(finalMeasure, OnFinalMeasurePixels);
    }

    private void RenderMeasure<TCell>(IGraphMeasure<TCell> graphMeasure, Action<IEnumerable<ImageColor>> action)
      where TCell : ICellCoordinate
    {
      myLogger.Write("Rendering Measure image...");
      var conv = CoordinateConverter<TCell>.CreateCoordinatesConverter(graphMeasure);
      action(graphMeasure.GetMeasureNodes().Select(x => conv.Convert3(x.Key, x.Value)));
    }

    private void RenderGraphComponents<TCell>(IGraphStrongComponents<TCell> components)
      where TCell : ICellCoordinate
    {
      var gconv = CoordinateConverter<TCell>.CreateCoordinatesConverter(components);
      var pixels = components.GetCoordinates(components.Components).Select(x => gconv.Convert3(x, 0)).ToArray();
      var norm = pixels.Sum(x => x.Color);
      OnGraphPixels(pixels.Select(x=>x.Norm(norm)));
    }
  }
}
