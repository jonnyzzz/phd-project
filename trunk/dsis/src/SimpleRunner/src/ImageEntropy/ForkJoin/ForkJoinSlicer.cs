using System.Collections.Generic;
using System.Drawing;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  [ComponentImplementation]
  public class ForkJoinSlicer
  {
    public IEnumerable<ForkJoinDataSlice> SplitImage(ForkJoinImageEntropyParameters parameters, ImageEntropyData data)
    {
      var image = data.Image;
      var list = new List<ForkJoinDataSlice>();

      var sliceX = parameters.SliceX;
      var sliceY = parameters.SliceY;

      for (int sX = 0; sX < image.Width; sX += sliceX)
        for (int sY = 0; sY < image.Height; sY += sliceY)
        {
          var bm = new Bitmap(sliceX, sliceY);
          for (int x = sX; x <= sX + sliceX; x++)
          {
            for (int y = sY; y <= sY + sliceY; y++)
            {
              bm.SetPixel(x - sX, y - sY, image.GetPixel(x, y));
            }
          }

          var p = data.CloneData();
          p.Image = bm;
          list.Add(new ForkJoinDataSlice(new ImagePixel(sX, sY), p));
        }

      return list;
    }

  }
}