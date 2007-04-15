using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Mock;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  public abstract class CellConnectionBuilderPerformanceTestBase
  {
    protected ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    protected IntegerCoordinateSystem myIcs;

    protected abstract IntegerCoordinateSystem CreateCoodinateSystem();

    [SetUp]
    public void SetUp()
    {
      myBuilder = new MockCellConnectionBuilder<IntegerCoordinate>();
      myIcs = CreateCoodinateSystem();
    }

    [TearDown]
    public void TeamDown()
    {
      myBuilder = null;
      myIcs = null;
    }


    protected static void Iterate<T>(IEnumerable<T> t)
    {
      foreach (T t1 in t)
      {        
      }
    }
  }
}