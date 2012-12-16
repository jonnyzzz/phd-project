using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DSIS.Graph.Images;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public static class ImageHelpers
  {
    public static Image RenderProcessedImage(ImageEntropyData data, IEnumerable<ImageColor> pixels)
    {
      pixels = pixels.ToArray();

      var img = new Bitmap(data.Image.Width, data.Image.Height);
      double minValue = pixels.Min(x => x.Color);
      double maxValue = pixels.Max(x => x.Color);

      Color minColor = data.RenderMinColor;
      Color maxColor = data.RenderMaxColor;

      Func<Color, double> R = c => c.R;
      Func<Color, double> G = c => c.G;
      Func<Color, double> B = c => c.B;
      Func<double, Func<Color, double>, int> y =
        (x, F) => (int) ((x - minValue)/(maxValue - minValue)*(F(maxColor) - F(minColor)) + F(minColor));

      var color =
        Math.Abs(minValue - maxValue) > 1e-8
          ? (Func<double, Color>) (d => Color.FromArgb(y(d, R), y(d, G), y(d, B)))
          : d => Color.Crimson;

      using (var g = Graphics.FromImage(img))
      {
        g.Clear(Color.White);
      }

      foreach (var p in pixels)
      {
        img.SetPixel(p.X, p.Y, color(p.Color));
      }

      return img;
    }

    public static Image ZoomImageIfNeeded(int height, int width, Image image)
    {
      var i = new Bitmap(image);

      var ih = i.Height;
      var iw = i.Width;
      var mh = 1;
      var mw = 1;

      while (height > ih || width > iw) { ih <<= 1; mh <<= 1; iw <<= 1; mw <<= 1; }

      var bm = new Bitmap(iw, ih);
      for (int x = 0; x < i.Width; x++)
      {
        for (int y = 0; y < i.Height; y++)
        {
          var c = i.GetPixel(x, y);
          for(int nx = 0; nx < mw; nx++)
          {
            for(int ny = 0; ny < mh; ny++)
            {
              bm.SetPixel(x*mw+nx, y*mh+ny, c);
            }
          }
        }
      }
      return bm;
    }

    public static IEnumerable<ImageColor> ImageToPixels(Bitmap img, GraphFromImageBuilderParameters ps)
    {
      var expression = ps.Hash.Compile();
      return img.ImageToPixels().Select(x => new ImageColor(x.X, x.Y, expression(img.GetPixel(x.X, x.Y))));
    }

    public static IEnumerable<ImagePixel> ImageToPixels(this Bitmap img)
    {
      for (int x = 0; x < img.Width; x++)
      {
        for (int y = 0; y < img.Height; y++)
        {
          yield return new ImagePixel(x, y);
        }
      }
    }

    public static Bitmap Crop(this Bitmap img, int fromX, int toX, int fromY, int toY)
    {
      var copy = new Bitmap(img, toX - fromX + 1, toY - fromY + 1);
      for (int x = fromX; x <= toX; x++)
      {
        for (int y = fromY; y <= toY; y++)
        {
          copy.SetPixel(x - fromX, y - fromY, img.GetPixel(x, y));
        }
      }
      return copy;
    }


    /// <summary>
    /// Connr
    /// </summary>
    /// <param name="img"></param>
    /// <param name="fromX"></param>
    /// <param name="toX"></param>
    /// <param name="fromY"></param>
    /// <param name="toY"></param>
    /// <returns></returns>
    public static IEnumerable<ImagePixel> ImageToPixels(this Bitmap img, int fromX, int toX, int fromY, int toY)
    {
      for (int x = fromX; x < toX; x++)
      {
        for (int y = fromY; y < toY; y++)
        {
          yield return new ImagePixel(x, y);
        }
      }
    }

  }
}