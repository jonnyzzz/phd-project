using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;

namespace DSIS.IntegerCoordinates.Test
{
  public abstract class CellConnectionAdapterTestBase
  {
    protected static List<IntegerCoordinate> DoTest(IntegerCoordinateSystem ics, DoBuild bld)
    {
      MockCollectingCellConnectionBuilder<IntegerCoordinate> mcm =
        new MockCollectingCellConnectionBuilder<IntegerCoordinate>();

      bld(mcm);

      return mcm.Result;
    }

    protected delegate void DoBuild(ICellConnectionBuilder<IntegerCoordinate> bld);
  }
}