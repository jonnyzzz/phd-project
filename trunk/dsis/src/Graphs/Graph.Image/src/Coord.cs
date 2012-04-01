using System;

namespace DSIS.Graph.Images
{
  internal struct Coord : IEquatable<Coord>
  {
    public readonly int X;
    public readonly int Y;

    public Coord(int x, int y)
    {
      X = x;
      Y = y;
    }

    public bool Equals(Coord other)
    {
      return other.X == X && other.Y == Y;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (obj.GetType() != typeof(Coord)) return false;
      return Equals((Coord)obj);
    }

    public override int GetHashCode()
    {
      unchecked { return (X * 397) ^ Y; }
    }

    public static bool operator ==(Coord left, Coord right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Coord left, Coord right)
    {
      return !left.Equals(right);
    }
  }
}