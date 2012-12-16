using System;
using System.Drawing;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public static class WellknownTestImages
  {
    public static Bitmap Cross(int w, int thickness)
    {
      var img = WhiteBitmap(w, w);
      Render(img, (x, y) => Math.Abs(x - y) <= thickness || Math.Abs(x + y - w) <= thickness);
      return img;
    }

    public static Bitmap HLines2(int w, int h, int thickness)
    {
      var img = WhiteBitmap(w, h);
      Render(img, (x, y) => Math.Abs(x - w/4) <= thickness || Math.Abs(x - 3*w/4) <= thickness);
      return img;
    }

    public static Bitmap HVLines2(int w, int h, int thickness)
    {
      var img = WhiteBitmap(w, h);
      Render(img,
             (x, y) =>
             false
             || Math.Abs(x - w/4) <= thickness
             || Math.Abs(x - 3*w/4) <= thickness
             || Math.Abs(y - h/4) <= thickness
             || Math.Abs(y - 3*h/4) <= thickness
             );
      return img;
    }

    public static Bitmap VLines(int w, int h, int thickness, int step)
    {
      var img = WhiteBitmap(w, h);
      Render(img, (x,y) => Math.Abs(x%step) <= thickness);
      return img;
    }

    public static Bitmap HLines(int w, int h, int thickness, int step)
    {
      var img = WhiteBitmap(w, h);
      Render(img, (x,y) => Math.Abs(y%step) <= thickness);
      return img;
    }

    private static Bitmap WhiteBitmap(int w, int h)
    {
      var img = new Bitmap(w, h);
      for (int x = 0; x < w; x++) 
        for (int y = 0; y < h; y++) 
          img.SetPixel(x, y, Color.White);

      return img;
    }

    private static void Render(Bitmap b, Func<int, int, bool> f)
    {
      Render(b, (x,y) => f(x,y) ? (Color?)Color.Black : null);
    }

    private static void Render(Bitmap b, Func<int, int, Color?> f)
    {
      for (int x = 0; x < b.Width; x++)
      {
        for (int y = 0; y < b.Height; y++)
        {
          Color? color = f(x, y);
          if (color != null) b.SetPixel(x, y, color.Value);
        }
      }
    }
  }
}