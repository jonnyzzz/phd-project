using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateDebug
  {
    long GetCoordinate(int index);
  }

  public interface IIntegerCoordinate<T> : ICellCoordinate<T> where T : IIntegerCoordinate<T>
  {
    long GetCoordinate(int index);
    int Dimension { get; }    
  }
}