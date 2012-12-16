using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy
{
  [ComponentImplementation]
  public class ImageEntropyBuilderPolicy : IImageEntropyBuilderPolicy
  {
    public bool Accept(EntropyBuildParameters data)
    {
      return data is SimpleEntropyBuildParameters;
    }

    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    private static IEnumerable<ImageColor> DiffImages(IEnumerable<ImageColor> startColor, IEnumerable<ImageColor> endColor)
    {
      IDictionary<ImagePixel, double> myData = new Dictionary<ImagePixel, double>(ImagePixel.XYComparer);

      foreach (var color in startColor)
      {
        double v;
        if (!myData.TryGetValue(color.Pixel, out v)) v = 0;
        myData[color.Pixel] = v + color.Color;
      }

      foreach (var color in endColor)
      {
        double v;
        if (!myData.TryGetValue(color.Pixel, out v)) v = 0;
        myData[color.Pixel] = v - color.Color;
      }

      return myData.Select(p => new ImageColor(p.Key, p.Value));
    }


    public void ComputeMeasure(ImageEntropyData sys,
                               Func<string, Action<IEnumerable<ImageColor>>> saver,
                               Logger logger)
    {
      logger.Write("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      logger.Write("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);


      var pixels = ImageHelpers.ImageToPixels(sys.Image, sys.GraphParameters).ToArray();
      saver("loaded")(pixels);

      IEnumerable<ImageColor> initialMeasure = null;

      new ComputeImageMeasureAction(sys, logger)
        {
          OnGraphPixels = saver("graph"),
          OnInitialMeasurePixels = m =>
                                     {
                                       initialMeasure = m.ToArray();
                                       saver("jvr-init")(initialMeasure);
                                     },
          OnFinalMeasurePixels = m =>
                                   {
                                     saver("jvr-finish")(m);
                                     saver("jvr-diff")(DiffImages(initialMeasure, m));
                                   }
        }.Apply(graph);
    }
  }
}