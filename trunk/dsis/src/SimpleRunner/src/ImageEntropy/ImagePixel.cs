using System;
using System.Collections.Generic;

namespace DSIS.SimpleRunner.ImageEntropy
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

    public static ImagePixel operator +(ImagePixel p1, ImagePixel p2)
    {
      return new ImagePixel(p1.X + p2.X, p1.Y + p2.Y);
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
}