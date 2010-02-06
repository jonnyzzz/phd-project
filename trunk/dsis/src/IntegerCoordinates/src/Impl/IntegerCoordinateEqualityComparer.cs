using System.Collections.Generic;

namespace DSIS.IntegerCoordinates.Impl
{
  public struct IntegerCoordinateEqualityComparer : IEqualityComparer<IntegerCoordinate>
  {
    public static IntegerCoordinateEqualityComparer INSTANCE = new IntegerCoordinateEqualityComparer();

    public bool Equals(IntegerCoordinate x, IntegerCoordinate y)
    {
      for (int len = 0; len < x.Dimension; len++)
      {
        if (x.GetCoordinate(len) != y.GetCoordinate(len))
          return false;
      }
      return true;
    }

    public int GetHashCode(IntegerCoordinate obj)
    {
      int hash1 = 0;
      int hash2 = 1;
      for (int i = 0; i < obj.Dimension; i++)
      {
        hash1 += (int) obj.GetCoordinate(i);
        hash2 *= (int) obj.GetCoordinate(i) + 1;
      }
      return hash1 + hash2;
    }
  }
}