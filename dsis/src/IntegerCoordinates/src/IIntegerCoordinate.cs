using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinate : ICellCoordinate
  {
    long GetCoordinate(int index);
    int Dimension { get; }    
  }  
}