using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  [ComponentImplementation]
  public class ForkJoinSlicer
  {
    public IEnumerable<ForkJoinDataSlice> SplitImage(ForkJoinImageEntropyParameters parameters, ImageEntropyData data)
    {
      var slices =
        from x in SliceRow(0, data.Image.Width - 1, parameters.SliceX)
        from y in SliceRow(0, data.Image.Height - 1, parameters.SliceY)
        select new {SliceX = x, SliceY = y};

      return slices.Select(
        s =>
          {
            var x = s.SliceX;
            var y = s.SliceY;
            var p = data.CloneData();
            p.Image = data.Image.Crop(x.First, x.Second, y.First, y.Second);
            return new ForkJoinDataSlice(new ImagePixel(x.First, y.First), p);
          }
        ).ToArray();
    }

    private IEnumerable<Pair<int, int>> SliceRow(int from, int to, int sliceSize)
    {
      if (to <= from) return EmptyArray<Pair<int, int>>.Instance;

      if (to - from >= 2*sliceSize)
        return Pair.Of(from, from + sliceSize).Enum().Union(SliceRow(from + sliceSize, to, sliceSize));

      return Pair.Of(from, to).Enum();
    }
  }
}