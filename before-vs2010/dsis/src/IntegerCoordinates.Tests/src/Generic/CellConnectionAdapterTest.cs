using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;

namespace DSIS.IntegerCoordinates.Tests.Generic
{
  public abstract class CellConnectionAdapterTestBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected MockSystemSpace mySpace;
    protected T myIcs;

    protected static List<Q> DoTest(T ics, DoBuild bld)
    {
      var mcm = new MockCollectingCellConnectionBuilder<Q>();

      bld(mcm);

      return mcm.Result;
    }

    protected delegate void DoBuild(ICellConnectionBuilder<Q> bld);
  }
}