using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.imageEntropy
{
  public abstract class ImageEntropyBuilderBase : ComputationBuilderBase<ImageEntropyData>
  {
    [Autowire]
    private GraphFromImageBuilder myBuilder { get; set; }

    protected override void ComputeAll(ImageEntropyData sys)
    {
      string home = @"e:\\temp\\image-entropy2\\" + sys.Name + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");

      Directory.CreateDirectory(home);
      var wf = new WorkingFolderInfo(home);
      var logger = new AndLogger(new ConsoleLogger(), new FileLogger(wf));

      sys.Image.Save(Path.Combine(home, sys.Name + ".original.png"), ImageFormat.Png);
      sys.Serialize(logger);
      Func<string, Action<IEnumerable<ImageColor>>> saver =
        name => pxls =>
                  {
                    var img = ImageHelpers.RenderProcessedImage(sys, pxls);
                    img.Save(Path.Combine(home, sys.Name + "." + name + ".png"), ImageFormat.Png);
                    var zimg = ImageHelpers.ZoomImageIfNeeded(1000, 1000, img);
                    zimg.Save(Path.Combine(home, sys.Name + "." + name + "-zoom.png"), ImageFormat.Png);
                  };

      ComputeMeasure(sys, saver, logger);
    }


    private void ComputeMeasure(ImageEntropyData sys, 
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