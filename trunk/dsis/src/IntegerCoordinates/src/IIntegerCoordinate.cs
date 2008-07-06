using System;
using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinate : ICellCoordinate
  {
    long GetCoordinate(int index);
    [Obsolete("Kill me")]
    int Dimension { get; }    
  }  
}