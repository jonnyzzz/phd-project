using System;
using System.Collections.Generic;

namespace DSIS.SimpleRunner.imageEntropy
{
  public struct ImagePixel : IEquatable<ImagePixel>
  {
    public readonly int X;
    public readonly int Y;

    public ImagePixel(int x, int y)
    {
      X = x;
      Y = y;
    }

    #region Equality members

    public bool Equals(ImagePixel other)
    {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      return obj is ImagePixel && Equals((ImagePixel) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (X*397) ^ Y;
      }
    }

    public static bool operator ==(ImagePixel left, ImagePixel right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(ImagePixel left, ImagePixel right)
    {
      return !left.Equals(right);
    }

    #endregion

    private sealed class XYEqualityComparer : IEqualityComparer<ImagePixel>
    {
      public bool Equals(ImagePixel x, ImagePixel y)
      {
        return x.X == y.X && x.Y == y.Y;
      }

      public int GetHashCode(ImagePixel obj)
      {
        unchecked
        {
          return (obj.X*397) ^ obj.Y;
        }
      }
    }

    private static readonly IEqualityComparer<ImagePixel> XYComparerInstance = new XYEqualityComparer();

    public static IEqualityComparer<ImagePixel> XYComparer
    {
      get { return XYComparerInstance; }
    }
  }

  public struct ImageColor : IEquatable<ImageColor>
  {
    public readonly int X;
    public readonly int Y;
    public readonly double Color;

    public ImageColor(ImagePixel p, double color) : this(p.X, p.Y, color)
    {
    }

    public ImageColor(int x, int y, double color)
    {
      X = x;
      Y = y;
      Color = color;
    }

    public ImageColor Norm(double x)
    {
      return new ImageColor(X, Y, Color/x);
    }

    public ImagePixel Pixel
    {
      get { return new ImagePixel(X, Y); }
    }

    #region Equality members

    public bool Equals(ImageColor other)
    {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      return obj is ImageColor && Equals((ImageColor) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (X*397) ^ Y;
      }
    }

    public static bool operator ==(ImageColor left, ImageColor right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(ImageColor left, ImageColor right)
    {
      return !left.Equals(right);
    }

    #endregion

    private sealed class XYEqualityComparer : IEqualityComparer<ImageColor>
    {
      public bool Equals(ImageColor x, ImageColor y)
      {
        return x.X == y.X && x.Y == y.Y;
      }

      public int GetHashCode(ImageColor obj)
      {
        unchecked
        {
          return (obj.X*397) ^ obj.Y;
        }
      }
    }

    private static readonly IEqualityComparer<ImageColor> XYComparerInstance = new XYEqualityComparer();

    public static IEqualityComparer<ImageColor> XYComparer
    {
      get { return XYComparerInstance; }
    }
  }
}