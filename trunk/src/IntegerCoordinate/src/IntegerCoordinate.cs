using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateDebug
  {
    long[] Coordinate { get;}
  }

  [EqualityComparer(typeof(IntegerCoordinateEqualityComparer))]
  public sealed class IntegerCoordinate : ICellCoordinate<IntegerCoordinate>, IIntegerCoordinateDebug
  {
    private long[] myCoordinare;

    public IntegerCoordinate(params long[] coordinare)
    {
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
      return IntegerCoordinateEqualityComparer.INSTANCE.Equals(this, ac);
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
      return IntegerCoordinateEqualityComparer.INSTANCE.GetHashCode(this);
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
