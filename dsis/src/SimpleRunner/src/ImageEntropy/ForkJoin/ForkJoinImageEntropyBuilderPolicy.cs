using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  [ComponentImplementation]
  public class ForkJoinImageEntropyBuilderPolicy : IImageEntropyBuilderPolicy
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    [Autowire]
    private ForkJoinSlicer mySlicer { get; set; }

    public bool Accept(EntropyBuildParameters data)
    {
      return data is ForkJoinImageEntropyParameters;
    }

    public void ComputeMeasure(ImageEntropyData sys, Func<string, Action<IEnumerable<ImageColor>>> saver, Logger logger)
    {
      var pixels = ImageHelpers.ImageToPixels(sys.Image, sys.GraphParameters).ToArray();
      saver("loaded")(pixels);

      var parameters = (ForkJoinImageEntropyParameters)sys.EntropyBuildParameters;
      var startTime = DateTime.Now;
      logger.Write("Start Parallel computations with " + parameters);

      var startMatrix = new DoubleMatrix();
      var finishMatrix = new DoubleMatrix();
      var slices = mySlicer.SplitImage(parameters, sys).ToArray();
      logger.Write("Total slices to process: {0}", slices.Count());

      slices
        .AsParallel()
        .ForAll(data =>
          {
            var subGraph = myBuilder.BuildGraphFromImage(data.Data.Image, data.Data.GraphParameters);
            new ComputeImageMeasureAction(data.Data, new NullLogger())
              {
                OnInitialMeasurePixels = result => startMatrix.AddRange(data.Coord, result),
                OnFinalMeasurePixels = result => finishMatrix.AddRange(data.Coord, result)
              }.Apply(subGraph);
            Console.Out.Write(".");
          });
      Console.Out.WriteLine("");
      logger.Write("Parallel computations completed in: {0}", (DateTime.Now - startTime).TotalMilliseconds);

      var fullGraph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      logger.LogComputedMeasures(fullGraph, new PixelsWeightCallback("initial", startMatrix.Weight), new PixelsWeightCallback("final", finishMatrix.Weight));

      saver("merged")(finishMatrix.Result);
      saver("initial")(startMatrix.Result);
    }


    private class DoubleMatrix
    {
      private readonly object myLock = new object();
      private readonly Dictionary<ImagePixel, double> myData = new Dictionary<ImagePixel, double>(ImagePixel.XYComparer);
      
      public void AddRange(ImagePixel offset, IEnumerable<ImageColor> data)
      {
        lock (myLock)
        {
          foreach (var c in data)
          {
            double v;
            var key = new ImagePixel(c.X, c.Y) + offset;

            myData.TryGetValue(key, out v);
            v += c.Color;
            myData[key] = v;
          }
        }
      }

      public double Weight(int x, int y)
      {
        double d;
        return myData.TryGetValue(new ImagePixel(x, y), out d) ? d : 0;
      }

      public IEnumerable<ImageColor> Result
      {
        get
        {
          return myData.Select(k => new ImageColor(k.Key.X, k.Key.Y, k.Value));
        }
      }
    }
  }
}