namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateSystemMultiplyConverter<T> 
    : ICellCoordinateSystemConverter<T,T> 
    where T : ICellCoordinate
  {
    long[] Division { get; }
  }
}