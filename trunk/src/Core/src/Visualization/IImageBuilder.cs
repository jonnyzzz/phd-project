using DSIS.Core.Util;

namespace DSIS.Core.Visualization
{
  public interface IImageBuilder
  {
    string CreatePointsGroup(double[] radius);

    void AddPoints<T>(
      IProgressInfo info,
      string pointGroup,
      ICellToPointConverter<T> converter,
      CountEnumerable<T> points);
  }
}