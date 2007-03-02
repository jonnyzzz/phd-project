using System.Collections.Generic;
using DSIS.Core.Mock;

namespace DSIS.IntegerCoordinates.Test
{
  public abstract class CellConnectionAdapterTestBase
  {
    protected static List<IntegerCoordinate> DoTest(IntegerCoordinateSystem ics, DoBuild bld)
    {
      MockCollectingCellConnectionBuilder<IntegerCoordinate> mcm =
        new MockCollectingCellConnectionBuilder<IntegerCoordinate>();

      IntegerCoordinateCellImageBuilderAdapter ad =
        new IntegerCoordinateCellImageBuilderAdapter(mcm, ics);

      bld(ad);

      return mcm.Result;
    }

    protected delegate void DoBuild(IntegerCoordinateCellImageBuilderAdapter ad);
  }
}