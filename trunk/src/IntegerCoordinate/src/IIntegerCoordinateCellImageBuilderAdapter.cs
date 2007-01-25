namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateCellImageBuilderAdapter
  {
    void ConnectCellToRect(IntegerCoordinate from, double[] left, double[] right, double[] eps);
  }
}