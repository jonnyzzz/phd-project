using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using DSIS.IntegerCoordinates.Tests;

namespace DSIS.IntegerCoordinates.Generic
{
  public abstract class CellConnectionAdapterTestBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected MockSystemSpace mySpace;
    protected T myIcs;

    protected static List<Q> DoTest(T ics, DoBuild bld)
    {
      MockCollectingCellConnectionBuilder<Q> mcm =
        new MockCollectingCellConnectionBuilder<Q>();

      bld(mcm);

      return mcm.Result;
    }

    protected delegate void DoBuild(ICellConnectionBuilder<Q> bld);
  }
}