using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateDebug
  {
    long[] GetCoordinates();
    long GetCoordinate(int index);
  }

  public interface IIntegerCoordinate<T> : ICellCoordinate<T> where T : IIntegerCoordinate<T>
  {
    long GetCoordinate(int index);
    int Dimension { get; }    
  }
}