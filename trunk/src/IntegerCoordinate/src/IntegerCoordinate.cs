using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateDebug
  {
    long[] Coordinate { get;}
  }

  public struct IntegerCoordinateEqualityComparer : IEqualityComparer<IntegerCoordinate>
  {
    public static IntegerCoordinateEqualityComparer INSTANCE = new IntegerCoordinateEqualityComparer();

    public bool Equals(IntegerCoordinate x, IntegerCoordinate y)
    {
      long[] xC = x.Coordinate;
      long[] yC = y.Coordinate;

      return Equals(xC, yC);
    }

    public static bool Equals(long[] xC, long[] yC)
    {
      for (int len = 0; len < xC.Length; len++)
      {
        if (xC[len] != yC[len])
          return false;
      }
      return true;
    }

    public int GetHashCode(IntegerCoordinate obj)
    {
      return GetHashCode(obj.Coordinate);
    }

    public static int GetHashCode(long[] x)
    {
      int hash = 0;
      unchecked
      {
        for (int i = x.Length - 1; i >= 0; i--)
        {
          hash += hash * 31 + (int)x[i] + i * 17;
        }
      }
      return hash;      
    }
  }

  [EqualityComparer(typeof(IntegerCoordinateEqualityComparer))]
  public sealed class IntegerCoordinate : ICellCoordinate<IntegerCoordinate>, IIntegerCoordinateDebug
  {
    private long[] myCoordinare;

    public IntegerCoordinate(params long[] coordinare)
    {
      if (coordinare == null)
        throw new ArgumentException("Null constructor", "coordinate");
      myCoordinare = coordinare;
    }

    public IntegerCoordinate Clone()
    {
      return new IntegerCoordinate((long[]) Coordinate.Clone());
    }

    internal long[] Coordinate
    {
      get { return myCoordinare; }
    }

    long[] IIntegerCoordinateDebug.Coordinate
    {
      get { return Coordinate; }
    }

    public IEqualityComparer<IntegerCoordinate> Comparer
    {
      get { return IntegerCoordinateEqualityComparer.INSTANCE; }
    }

    public bool Equals(IntegerCoordinate ac)
    {
      return IntegerCoordinateEqualityComparer.Equals(myCoordinare, ac.myCoordinare);
    }

    public override bool Equals(object obj)
    {
      if (this == obj) 
        return true;
      
      IntegerCoordinate integerCoordinate = obj as IntegerCoordinate;      
      if (integerCoordinate == null) 
        return false;

      return Equals(integerCoordinate);
    }

    public override int GetHashCode()
    {
      return IntegerCoordinateEqualityComparer.GetHashCode(myCoordinare);
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (long l in myCoordinare)
      {
        sb.AppendFormat("{0}, ", l);
      }
      return "[" + sb + "]";
    }
  }
}
