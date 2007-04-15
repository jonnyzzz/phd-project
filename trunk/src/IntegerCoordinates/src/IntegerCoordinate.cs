using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
{
  [EqualityComparer(typeof (IntegerCoordinateEqualityComparer))]
  public sealed class IntegerCoordinate : IIntegerCoordinate<IntegerCoordinate>, IIntegerCoordinateDebug
  {
    public readonly long[] myCoordinate;

    public IntegerCoordinate(params long[] coordinare)
    {
      myCoordinate = coordinare;
    }

    public IEqualityComparer<IntegerCoordinate> Comparer
    {
      get { return IntegerCoordinateEqualityComparer.INSTANCE; }
    }

    public bool Equals(IntegerCoordinate ac)
    {
      return IntegerCoordinateEqualityComparer.INSTANCE.Equals(this, ac);
    }

    public override int GetHashCode()
    {
      return IntegerCoordinateEqualityComparer.INSTANCE.GetHashCode(this);
    }

    long[] IIntegerCoordinateDebug.GetCoordinates()
    {
      return myCoordinate;
    }

    public IntegerCoordinate Clone()
    {
      return new IntegerCoordinate((long[]) myCoordinate.Clone());
    }

    public long GetCoordinate(int index)
    {
      return myCoordinate[index];
    }

    public int Dimension
    {
      get { return myCoordinate.Length; }
    }

    [Obsolete()]
    internal long[] Coordinate
    {
      get { return myCoordinate; }
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (long l in myCoordinate)
      {
        sb.AppendFormat("{0}, ", l);
      }
      return "[" + sb + "]";
    }
  }
}