using System;
using System.Collections.Generic;
using System.Text;
using DSIS.CellImageBuilder.BexMethodTest;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Util;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  public class CellConnectionAdapterTestBase
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