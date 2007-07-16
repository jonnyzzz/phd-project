namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateSystemProjector<T>
    where T : ICellCoordinate<T>
  {
    ICellCoordinateSystem<T> FromSystem { get; }
    ICellCoordinateSystem<T> ToSystem { get; }

    T Project(T coordinate);    
  }
}