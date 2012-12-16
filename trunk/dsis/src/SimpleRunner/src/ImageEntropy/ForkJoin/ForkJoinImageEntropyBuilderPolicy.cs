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
      logger.Write("Start Parallel computations with " + parameters);

      var matrix = new DoubleMatrix();
      var slices = mySlicer.SplitImage(parameters, sys).ToArray();
      logger.Write("Total slices to process: {0}", slices.Count());

      slices
        .AsParallel()
        .ForAll(data =>
          {
            logger.Write("Constructing graph for {0}", data.SliceName);

            var graph = myBuilder.BuildGraphFromImage(data.Data.Image, data.Data.GraphParameters);
            logger.Write("Constructed graph for {2} of {0}, edges {1}", graph.NodesCount, graph.EdgesCount, data.SliceName);
            new ComputeImageMeasureAction(data.Data, logger)
              {
                OnFinalMeasurePixels = result => matrix.AddRange(data.Coord, result)
              }.Apply(graph);

            logger.Write("Entropy completed graph: {0}", data.SliceName);
          });

      logger.Write("Parallel computations completed. ");

      saver("merged")(matrix.Result);
    }


    private class DoubleMatrix
    {
      private readonly Dictionary<ImagePixel, double> myData = new Dictionary<ImagePixel, double>(ImagePixel.XYComparer);

      public void AddRange(ImagePixel offset, IEnumerable<ImageColor> data)
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

      public IEnumerable<ImageColor> Result
      {
        get { return myData.Select(k => new ImageColor(k.Key.X, k.Key.Y, k.Value)); }
      }
    }
  }
}