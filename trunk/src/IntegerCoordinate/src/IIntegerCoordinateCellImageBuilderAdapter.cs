namespace DSIS.IntegerCoordinates
{
  public interface IIntegerCoordinateCellImageBuilderAdapter
  {
    /// <summary>
    /// Eps is relative
    /// </summary>
    /// <param name="from"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="eps"></param>
    void ConnectCellToRect(IntegerCoordinate from, double[] left, double[] right, double[] eps);


    void ConnectCellToPointWithRadius(IntegerCoordinate cs, double[] point, double[] size);


    void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percent);
    void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] oLeft, double[] oRight);

    void AddPointWithOverlappingPrepare(double[] percent, double[] lp, double[] rp);
  }
}