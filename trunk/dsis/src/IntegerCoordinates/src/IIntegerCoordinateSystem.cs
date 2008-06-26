using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateSystemWith {
     void Do<T, Q>(T system)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
  }

  public interface IIntegerCoordinateSystemInfo : ICellCoordinateSystem
  {
    double[] CellSize { get; }
    double[] CellSizeHalf { get; }

    void DoGeneric(IIntegerCoordinateSystemWith with);
  }

  public interface IIntegerCoordinateSystem<T> 
    : ICellCoordinateSystem<T>
    , IIntegerCoordinateSystemInfo 
    where T : IIntegerCoordinate
  {
    /// <summary>
    /// Writes to output array the point of top-left conner of cell 
    /// (point with minimal possible coordinate)
    /// </summary>
    /// <param name="point">input point</param>
    /// <param name="output">result array</param>
    void TopLeftPoint(T point, double[] output);
    void CenterPoint(T point, double[] output);

    long ToInternal(double point, int i);
    double ToExternal(long pt, int i);

    bool Intersects(long l, int axis);

    /// <summary>
    /// Returns default set of helper classes for building cells
    /// </summary>
    IProcessorFactory<T> ProcessorFactory { get; }

    T Create(params long[] param);
  }
}