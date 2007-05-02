using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Impl
{
  [EqualityComparer(typeof (IntegerCoordinateEqualityComparer))]
  public sealed class IntegerCoordinate : IIntegerCoordinate<IntegerCoordinate>
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

    public void CopyTo(long[] dest)
    {
      Array.Copy(myCoordinate, dest, myCoordinate.Length);
    }

    public long GetCoordinate(int index)
    {
      return myCoordinate[index];
    }

    public int Dimension
    {
      get { return myCoordinate.Length; }
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