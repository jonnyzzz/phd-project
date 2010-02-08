using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  [Obsolete]
  [EqualityComparer(typeof(IntegerCoordinate2dEqualityComparer))]
  public struct IntegerCoordinate2d : IIntegerCoordinate
  {
    public readonly long l1;
    public readonly long l2;

    public IntegerCoordinate2d(long l1, long l2)
    {
      this.l1 = l1;
      this.l2 = l2;
    }

    public long GetCoordinate(int index)
    {
      switch(index)
      {
        case 0:
          return l1;
        case 1:
          return l2;
        default:
          throw new IndexOutOfRangeException();
      }
    }

    public int Dimension
    {
      get { return 2; }
    }

    public override string ToString()
    {
      return string.Format("[{0}, {1}]", l1, l2);
    }
  }

  [Obsolete]
  public class IntegerCoordinate2dEqualityComparer : IEqualityComparer<IntegerCoordinate2d>
  {
    public static readonly IntegerCoordinate2dEqualityComparer INSTANCE = new IntegerCoordinate2dEqualityComparer();

    public bool Equals(IntegerCoordinate2d x, IntegerCoordinate2d y)
    {
      return x.l1 == y.l1 && x.l2 == y.l2;
    }

    public int GetHashCode(IntegerCoordinate2d obj)
    {
      return (int) (obj.l1 + obj.l2*93) & 0x7fffff;
    }
  }
}
