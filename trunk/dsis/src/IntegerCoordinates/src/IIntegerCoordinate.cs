using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{

  public interface IIntegerCoordinate
  {
    long GetCoordinate(int index);
    int Dimension { get; }    
  }

  public interface IIntegerCoordinate<T> : IIntegerCoordinate, ICellCoordinate<T> where T : IIntegerCoordinate<T>
  {
  }
}