using DSIS.Core.Builders;

namespace DSIS.IntegerCoordinates
{
  /// <summary>
  /// This class is not thread-safe. To use it from several threads use 
  /// several instances
  /// </summary>
  public class IntegerCoordinateCellImageBuilderAdapter : IIntegerCoordinateCellImageBuilderAdapter
  {
    private readonly PointWithOverlappingProcessor myOverlappingProcessor;
    private readonly RectProcessor myRectProcessor;
    private readonly RadiusProcessor myRadiusProcessor;

    private readonly ICellConnectionBuilder<IntegerCoordinate> myBuilder;

    private double[] myPercLeft;
    private double[] myPercRight;

    internal IntegerCoordinateCellImageBuilderAdapter(ICellConnectionBuilder<IntegerCoordinate> builder,
                                                      IntegerCoordinateSystem coordinateSystem)
    {
      myOverlappingProcessor = new PointWithOverlappingProcessor(coordinateSystem);
      myRectProcessor = new RectProcessor(coordinateSystem);
      myRadiusProcessor = new RadiusProcessor(coordinateSystem);

      myBuilder = builder;
      myPercLeft = new double[coordinateSystem.Dimension];
      myPercRight = new double[coordinateSystem.Dimension];
    }

    #region IIntegerCoordinateCellImageBuilderAdapter Members

    public void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] percent)
    {
      myOverlappingProcessor.AddPointWithOverlappingPrepare(percent, myPercLeft, myPercRight);
      myBuilder.ConnectToMany(cs, myOverlappingProcessor.AddPointWithOverlappingInternal(point, myPercLeft, myPercRight));
    }

    public void AddPointWithOverlapping(IntegerCoordinate cs, double[] point, double[] oLeft, double[] oRight)
    {
      myBuilder.ConnectToMany(cs, myOverlappingProcessor.AddPointWithOverlappingInternal(point, oLeft, oRight));
    }

    public void AddPointWithOverlappingPrepare(double[] percent, double[] lp, double[] rp)
    {
      myOverlappingProcessor.AddPointWithOverlappingPrepare(percent, lp, rp);
    }

    public void ConnectCellToPointWithRadius(IntegerCoordinate cs, double[] point, double[] size)
    {
      myBuilder.ConnectToMany(cs, myRadiusProcessor.ConnectCellToRectInternal(point, size));
    }

    public void ConnectCellToRect(IntegerCoordinate from, double[] left, double[] right, double[] eps)
    {
      myBuilder.ConnectToMany(from, myRectProcessor.ConnectCellToRectInternal(left, right, eps));
    }

    #endregion
  }
}