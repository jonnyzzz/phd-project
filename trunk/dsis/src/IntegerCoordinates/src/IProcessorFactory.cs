namespace DSIS.IntegerCoordinates
{
  public interface IProcessorFactory<T> where T : IIntegerCoordinate
  {
    IRadiusProcessor<T> CreateRadiusProcessor();

    IRectProcessor<T> CreateRectProcessor(double[] eps);
    IRectProcessor<T> CreateRectProcessor(double cellSizeFactor);

    IPointProcessor<T> CreatePointProcessor();
    IPointProcessor<T> CreateOverlapedPointProcessor(double cellSizePercent);
    IPointProcessor<T> CreateOverlapedPointProcessor(double[] cellSizePercent);
  }
}