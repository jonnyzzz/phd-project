using System.Collections.Generic;

namespace DSIS.IntegerCoordinates
{
  public interface IRadiusProcessor<T> where T : IIntegerCoordinate<T>
  {
    IEnumerable<T> ConnectCellToRadius(double[] point, double[] radius);
  }

  public interface IRectProcessor<T> where T : IIntegerCoordinate<T>
  {
    IEnumerable<T> ConnectCellToRect(double[] left, double[] right);
  }

  public interface IPointProcessor<T> where T : IIntegerCoordinate<T>
  {
    IEnumerable<T> AddPoint(double[] value);
  }


  public interface IProcessorFactory<T> where T : IIntegerCoordinate<T>
  {
    IRadiusProcessor<T> CreateRadiusProcessor();

    IRectProcessor<T> CreateRectProcessor(double[] eps);
    IRectProcessor<T> CreateRectProcessor(double cellSizeFactor);

    IPointProcessor<T> CreatePointProcessor();
    IPointProcessor<T> CreateOverlapedPointProcessor(double cellSizePercent);
    IPointProcessor<T> CreateOverlapedPointProcessor(double[] cellSizePercent);
  }
}
