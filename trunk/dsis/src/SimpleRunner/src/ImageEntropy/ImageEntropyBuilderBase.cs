using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using DSIS.Scheme.Impl.Actions.Files;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.imageEntropy 
{
  public abstract class ImageEntropyBuilderBase : ComputationBuilderBase<ImageEntropyData>
  {
    [Autowire]
    private ImageEntropyBuilderPolicy Policy { get; set; }

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

      Policy.ComputeMeasure(sys, saver, logger);
    }


  }
}