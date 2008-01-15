using System;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinate : ICellCoordinate
  {
    long GetCoordinate(int index);
    int Dimension { get; }    
  }

  [Obsolete("Use IIntegerCoordinate instead")]
  public interface IIntegerCoordinate<T> : IIntegerCoordinate, ICellCoordinate<T> 
    where T : IIntegerCoordinate<T>
  {
  }
}