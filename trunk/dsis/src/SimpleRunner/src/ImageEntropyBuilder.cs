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
      var bmp = new Bitmap(Image.FromFile(@"E:\work\dsis\dsis\img\pic_52_down.png"));

      var data = new ImageEntropyData
                   {
                     Image = bmp,
                     GraphParameters = new GraphFromImageBuilderParameters
                                         {
                                           NumberOfNeighboursPerAxis = 2,
                                           NumberOfEdgesPerPixel = 1,
                                           Hash = c => c.GetBrightness(),
                                           Threasold = 0.31
                                         }  
                   };

      yield return data.Enum();
    }    
  }
}