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
    public bool Equals(IntegerCoordinate x, IntegerCoordinate y)
    {
      return x.Equals(y);
    }

    public int GetHashCode(IntegerCoordinate obj)
    {
      return obj.GetHashCode();
    }
  }

  public sealed class IntegerCoordinate : ICellCoordinate<IntegerCoordinate>, IIntegerCoordinateDebug
  {
    private long[] myCoordinare;

    public IntegerCoordinate(params long[] coordinare)
    {
      if (coordinare == null)
        throw new ArgumentException("Null constructor", "coordinate");
      myCoordinare = coordinare;
    }

    public IntegerCoordinate  Clone()
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

    public bool Equals(IntegerCoordinate ac)
    {
      if (ac == null)
        return false;
      if (ReferenceEquals(myCoordinare, ac.myCoordinare))
        return true;
      
      if (ac.myCoordinare.Length != myCoordinare.Length)
        return false;
      
      for(int len = myCoordinare.Length-1; len >= 0; len--)
      {
        if (myCoordinare[len] != ac.myCoordinare[len])
          return false;
      }
      return true;
    }

    public int CompareTo(IntegerCoordinate other)
    {
      if (other == null || myCoordinare.Length != other.myCoordinare.Length)
        throw new ArgumentException("Dimensions are different");
       
      for (int i = other.myCoordinare.Length - 1; i >= 0; i--)
      {
        if (other.myCoordinare[i] < myCoordinare[i])
          return -1;
        if (other.myCoordinare[i] > myCoordinare[i])
          return 1;
      }
      return 0;
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
      int hash = 0;
      unchecked
      {
        for (int i = myCoordinare.Length - 1; i >= 0; i--)
        {
          hash = hash*31 + (int) myCoordinare[i] + (int)(myCoordinare[i]>>32) + i * 17;
        }
      }
      return hash;
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
