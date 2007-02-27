using System.Collections.Generic;
using DSIS.Core.Mock;
using DSIS.IntegerCoordinates;

namespace DSIS.IntegerCoordinates.Test
{
  public abstract class CellConnectionAdapterTestBase
  {
    protected delegate void DoBuild(IntegerCoordinateCellImageBuilderAdapter ad);

    protected static List<IntegerCoordinate> DoTest(IntegerCoordinateSystem ics, DoBuild bld)
    {
      MockCellConnectionManager<IntegerCoordinate> mcm = 
        new MockCellConnectionManager<IntegerCoordinate>();

      IntegerCoordinateCellImageBuilderAdapter ad = 
        new IntegerCoordinateCellImageBuilderAdapter(mcm, ics);

      bld(ad);

      return mcm.Result;
    }
  }
}