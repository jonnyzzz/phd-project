using System.Collections.Generic;

namespace DSIS.Core.Visualization
{
  public interface ICellToPointConverter<T>
  {
    IEnumerable<ImagePoint> Convert(T t);
  }
}