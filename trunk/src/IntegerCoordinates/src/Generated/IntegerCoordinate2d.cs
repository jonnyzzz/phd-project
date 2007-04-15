using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Generated
{
  [EqualityComparer(typeof(IntegerCoordinate2dEqualityComparer))]
  public struct IntegerCoordinate2d : ICellCoordinate<IntegerCoordinate2d>, IIntegerCoordinateDebug
  {
    public readonly long l1;
    public readonly long l2;

    public IntegerCoordinate2d(long l1, long l2)
    {
      this.l1 = l1;
      this.l2 = l2;
    }

    public IEqualityComparer<IntegerCoordinate2d> Comparer
    {
      get { return IntegerCoordinate2dEqualityComparer.INSTANCE; }
    }

    public bool Equals(IntegerCoordinate2d coord)
    {
      return IntegerCoordinate2dEqualityComparer.INSTANCE.Equals(this, coord);
    }


    public long[] GetCoordinates()
    {
      throw new NotImplementedException();
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
  }

  public class IntegerCoordinate2dEqualityComparer : IEqualityComparer<IntegerCoordinate2d>
  {
    public static readonly IntegerCoordinate2dEqualityComparer INSTANCE = new IntegerCoordinate2dEqualityComparer();

    public bool Equals(IntegerCoordinate2d x, IntegerCoordinate2d y)
    {
      return x.l1 == y.l1 && x.l2 == y.l2;
    }

    public int GetHashCode(IntegerCoordinate2d obj)
    {
      return (int) (obj.l1 + obj.l2*93);
    }
  }

//  public class IntegerCoordinateSystem2d : IntegerCoordinateSystemBase, IIntegerCoordinateSystem
//  {
//    public IntegerCoordinateSystem2d(ISystemSpace systemSpace, long[] subdivision) : base(systemSpace, subdivision)
//    {
//    }
//
//    public IntegerCoordinateSystem2d(ISystemSpace systemSpace) : base(systemSpace)
//    {
//    }
//
//
//
//
//  }
}
