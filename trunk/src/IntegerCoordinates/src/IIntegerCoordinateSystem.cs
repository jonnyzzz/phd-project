using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateSystem<T> : ICellCoordinateSystem<T> where T : IIntegerCoordinate<T>
  {
    /// <summary>
    /// Writes to output array the point of top-left conner of cell 
    /// (point with minimal possible coordinate)
    /// </summary>
    /// <param name="point">input point</param>
    /// <param name="output">result array</param>
    void TopLeftPoint(T point, double[] output);
    void CenterPoint(T point, double[] output);

    double[] CellSize { get; }
    double[] CellSizeHalf { get; }

    long ToInternal(double point, int i);
    double ToExternal(long pt, int i);

    bool Intersects(long l, int axis);

    T Create(params long[] param);

    IProcessorFactory<T> ProcessorFactory { get; }
  }
}