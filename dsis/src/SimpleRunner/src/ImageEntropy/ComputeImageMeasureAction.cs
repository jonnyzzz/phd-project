using System;
using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.ImageEntropy
{
  internal class ComputeImageMeasureAction : ComputeImageMeasureActionBase
  {
    private readonly ImageEntropyData myParameters;

    public Action<IEnumerable<ImageColor>> OnFinalMeasurePixels { get; set; }
    public Action<IEnumerable<ImageColor>> OnInitialMeasurePixels { get; set; }


    public ComputeImageMeasureAction(ImageEntropyData parameters, Logger logger) : base(logger)
    {
      myParameters = parameters;
      OnFinalMeasurePixels = _ => { };
      OnInitialMeasurePixels = _ => { };
    }

    protected override IEntropyEdgeWeightCallback CreateInitialWeightCallback()
    {
      return myParameters.AsEntropyWeightCallback();
    }

    protected override Action<LoggingJVRMeasure<TCell>> SetupIterateMeasure<TCell, TNode>(JVRMeasureOptions jvrMeasureOptions)
    {
      jvrMeasureOptions.EPS = myParameters.MeasurePrecision ?? 1e-8;      
      var fun = base.SetupIterateMeasure<TCell, TNode>(jvrMeasureOptions);
      return j =>
        {
          fun(j);
          j.ExecutionSpan = myParameters.MeasureTimeout;
          j.MaxSteps = myParameters.MeasureIterations;
        };
    }

    protected override void IterateMeasure<TCell, TNode>(LoggingJVRMeasure<TCell> j, JVRMeasureOptions jvrMeasureOptions)
    {
      var initialMeasure = j.CreateEvaluatorCopy();
      RenderMeasure(initialMeasure, OnInitialMeasurePixels);

      myLogger.Write("Computing measure: Iterating over graph to compute measure...");
      j.Iterate(jvrMeasureOptions.EPS);
      myLogger.Write("Computing measure: Iterating over graph to compute measure: DOME...");

      var finalMeasure = j.CreateEvaluatorCopy();
      LogComputedMeasures(finalMeasure, initialMeasure);

      RenderMeasure(finalMeasure, OnFinalMeasurePixels);
    }
  }
}
