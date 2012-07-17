using System;
using System.Collections.Generic;
using System.Drawing;
using DSIS.Scheme.Impl.Actions.Files;
using System.Linq;

namespace DSIS.SimpleRunner.imageEntropy
{
  public class ForkJoinImageEntropyBuilderPolicy : IImageEntropyBuilderPolicy
  {
    public void ComputeMeasure(ImageEntropyData sys, Func<string, Action<IEnumerable<ImageColor>>> saver, Logger logger)
    {
      
    }

    private IEnumerable<EntropyDataSlice> SplitImage(int sliceX, int sliceY, ImageEntropyData data)
    {
      var image = data.Image;
      var list = new List<EntropyDataSlice>();
      
      for(int sX = 0; sX < image.Width; sX += sliceX)
      for(int sY = 0; sY < image.Height; sY += sliceY)
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
        list.Add(new EntropyDataSlice(new C(sX, sY), p));
      }

      return list;
    }

    private struct EntropyDataSlice
    {
      public readonly C Coord;
      public readonly ImageEntropyData Data;

      public EntropyDataSlice(C c, ImageEntropyData data)
      {
        Coord = c;
        Data = data;
      }
    }

    private struct C : IEquatable<C>
    {
      public readonly int X;
      public readonly int Y;

      public C(int x, int y)
      {
        X = x;
        Y = y;
      }

      public bool Equals(C other)
      {
        return other.X == X && other.Y == Y;
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != typeof (C)) return false;
        return Equals((C) obj);
      }

      public override int GetHashCode()
      {
        unchecked
        {
          return (X*397) ^ Y;
        }
      }

      public static bool operator ==(C left, C right)
      {
        return left.Equals(right);
      }

      public static bool operator !=(C left, C right)
      {
        return !left.Equals(right);
      }
    }
  }
}