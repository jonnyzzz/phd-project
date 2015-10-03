namespace DSIS.IntegerCoordinates.Generated
{
  public interface IIntegerCoordinateCallback
  {
    void Do<T, Q>(CreateSystem<T> createSystem)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
  }
}