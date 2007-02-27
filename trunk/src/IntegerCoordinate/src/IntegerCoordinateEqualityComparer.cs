using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public struct IntegerCoordinateEqualityComparer : IEqualityComparer<IntegerCoordinate>
  {
    public static IntegerCoordinateEqualityComparer INSTANCE = new IntegerCoordinateEqualityComparer();

    public bool Equals(IntegerCoordinate x, IntegerCoordinate y)
    {
      long[] xC = x.Coordinate;
      long[] yC = y.Coordinate;

      for (int len = 0; len < xC.Length; len++)
      {
        if (xC[len] != yC[len])
          return false;
      }
      return true;
    }

    public int GetHashCode(IntegerCoordinate obj)
    {
      long[] x = obj.Coordinate;          
      unchecked
      {
        int hash1 = 0;
        int hash2 = 1;
        for (int i = x.Length - 1; i >= 0; i--)
        {
          hash1 += (int)x[i];
          hash2 *= (int)x[i] + 1;
        }
        return hash1 + hash2;
      }      
    }
  }
}