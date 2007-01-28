namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateCellImageBuilderAdapter
  {
    void ConnectCellToRect(IntegerCoordinate from, double[] left, double[] right, double[] eps);
    void ConnectCellToPointWithRadius(IntegerCoordinate cs, double[] point, double[] size);
    void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percent);
    void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percentLeft, double[] percentRight);
    void AddPointWithOverlappingPrepare(double[] percent, double[] lp, double[] rp);
  }
}