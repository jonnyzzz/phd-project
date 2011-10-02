using System.Collections.Generic;
using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner
{
  [ComponentImplementation]
  public class ImageEntropyBuilder : ImageEntropyBuilderBase
  {
    protected override IEnumerable<IEnumerable<ImageEntropyData>> GetSystemsToRun2()
    {
      var bmp = new Bitmap(100, 100);

      var data = new ImageEntropyData
                   {
                     Image = bmp,
                     GraphParameters = new GraphFromImageBuilderParameters
                                         {
                                           Hash = c => c.GetBrightness(),
                                           Threasold = 0.01
                                         }
                   };

      yield return data.Enum();
    }    
  }
}