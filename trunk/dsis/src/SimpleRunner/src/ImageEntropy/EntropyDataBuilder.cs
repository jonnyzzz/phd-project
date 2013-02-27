using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme.Impl.Actions.Files;
using JetBrains.Annotations;

namespace DSIS.SimpleRunner.ImageEntropy
{
  internal static class EntropyDataBuilder
  {
    public static void LogComputedMeasures(this Logger logger, IReadonlyGraph graph, IEntropyEdgeWeightCallback start, IEntropyEdgeWeightCallback finish)
    {
      graph.DoGeneric(new WithGraph(logger, logger, start, finish));
    }

    private class EntropyDataBuildHelper : ComputeImageMeasureActionBase
    {
      private readonly IEntropyEdgeWeightCallback myWeight;
      public IGraphEntropy Entropy { get; set; }

      public EntropyDataBuildHelper([NotNull] Logger logger, IEntropyEdgeWeightCallback weight)
        : base(logger)
      {
        myWeight = weight;
      }

      protected override IEntropyEdgeWeightCallback CreateInitialWeightCallback()
      {
        return myWeight;
      }

      protected override void IterateMeasure<TCell, TNode>(LoggingJVRMeasure<TCell> j,
                                                           JVRMeasureOptions jvrMeasureOptions)
      {
        Entropy = j.CreateEvaluatorCopy();
      }
    }

    private class WithGraph : IReadonlyGraphWith
    {
      private readonly Logger myLogger;
      private readonly Logger myInternalLogger;
      private readonly IEntropyEdgeWeightCallback myStartMeasure;
      private readonly IEntropyEdgeWeightCallback myFinishMeasure;

      public WithGraph(Logger logger, Logger internalLogger, IEntropyEdgeWeightCallback startMeasure, IEntropyEdgeWeightCallback finishMeasure)
      {
        myLogger = logger;
        myInternalLogger = internalLogger;
        myStartMeasure = startMeasure;
        myFinishMeasure = finishMeasure;
      }

      public void With<TCell, TNode>(IReadonlyGraph<TCell, TNode> graph) where TCell : ICellCoordinate where TNode : class, INode<TCell>
      {
        var bld1 = new EntropyDataBuildHelper(myInternalLogger, myStartMeasure);
        bld1.With(graph);
        var initialMeasure = (IGraphMeasure<TCell>) bld1.Entropy;

        var bld2 = new EntropyDataBuildHelper(myInternalLogger, myFinishMeasure);
        bld2.With(graph);
        var finalMeasure = (IGraphMeasure<TCell>) bld2.Entropy;

        myLogger.Write("Measure computed (Osipenko): {0}", finalMeasure.GetEntropy());
        myLogger.Write("Measure computed (Relative): {0}", finalMeasure.ComputeRelativeEntropy(initialMeasure));
      }
    }
  }
}