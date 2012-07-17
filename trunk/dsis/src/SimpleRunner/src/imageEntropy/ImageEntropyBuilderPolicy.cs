using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.imageEntropy
{
  [ComponentImplementation]
  public class ImageEntropyBuilderPolicy : IImageEntropyBuilderPolicy
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    public void ComputeMeasure(ImageEntropyData sys,
                               Func<string, Action<IEnumerable<ImageColor>>> saver,
                               Logger logger)
    {
      logger.Write("Constructing graph...");
      var graph = myBuilder.BuildGraphFromImage(sys.Image, sys.GraphParameters);
      logger.Write("Constructed graph of {0}, edges {1}", graph.NodesCount, graph.EdgesCount);


      var pixels = ImageHelpers.ImageToPixels(sys.Image, sys.GraphParameters).ToArray();
      saver("loaded")(pixels);

      new ComputeImageMeasureAction(sys, logger)
        {
          OnGraphPixels = saver("graph"),
          OnInitialMeasurePixels = saver("jvr-init"),
          OnFinalMeasurePixels = saver("jvr-finish")
        }.Apply(graph);
    }
  }
}