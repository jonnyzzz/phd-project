using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class CellCoordinateCollection<T> : CountEnumerable<T>, ICellCoordinateCollection<T> 
    where T : ICellCoordinate
  {
    public ICellCoordinateSystem<T> System { get; private set; }

    public CellCoordinateCollection(ICellCoordinateSystem<T> system, IEnumerable<T> collection, long count) : base(collection, count)
    {
      System = system;
    }

    public CellCoordinateCollection(ICellCoordinateSystem<T> system, ICountEnumerable<T> enu) : base(enu, enu.Count)
    {
      System = system;
    }
  }
}