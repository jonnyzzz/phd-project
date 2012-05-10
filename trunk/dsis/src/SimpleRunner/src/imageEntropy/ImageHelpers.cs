using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DSIS.Graph.Images;

namespace DSIS.SimpleRunner.imageEntropy
{
  public static class ImageHelpers
  {
    public static Image RenderProcessedImage(ImageEntropyData data, IEnumerable<ImageColor> pixels)
    {
      pixels = pixels.ToArray();

      var img = new Bitmap(data.Image.Width, data.Image.Height);
      double minValue = pixels.Min(x => x.Color);
      double maxValue = pixels.Max(x => x.Color);

      Color minColor = Color.White;
      Color maxColor = Color.MediumSeaGreen;

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

    public static IEnumerable<ImageColor> ImageToPixels(Bitmap img, GraphFromImageBuilderParameters ps)
    {
      var expression = ps.Hash.Compile();
      for (int x = 0; x < img.Width; x++)
      {
        for (int y = 0; y < img.Height; y++)
        {
          yield return new ImageColor {X = x, Y = y, Color = expression(img.GetPixel(x, y))};
        }
      }
    }
  }

  public struct ImageColor
  {
    public int X;
    public int Y;
    public double Color;
  }

}