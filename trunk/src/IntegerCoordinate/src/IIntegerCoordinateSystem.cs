using DSIS.Core.Coordinates;

namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateSystem : ICellCoordinateSystem<IntegerCoordinate>
  {
    /// <summary>
    /// Writes to output array the point of top-left conner of cell 
    /// (point with minimal possible coordinate)
    /// </summary>
    /// <param name="point">input point</param>
    /// <param name="output">result array</param>
    void TopLeftPoint(IntegerCoordinate point, double[] output);


    IIntegerCoordinateCellImageBuilderAdapter CreateAdapter(ICellConnectionBuilder<IntegerCoordinate> builder);

    double[] CellSize { get; }

    double[] CellSizeHalf { get; }
  }
}