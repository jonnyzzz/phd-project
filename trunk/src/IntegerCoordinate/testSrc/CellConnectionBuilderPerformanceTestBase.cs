using System.Collections.Generic;
using DSIS.Core.Coordinates;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  public abstract class CellConnectionBuilderPerformanceTestBase
  {
    protected ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    protected IntegerCoordinateSystem myIcs;
    protected IIntegerCoordinateCellImageBuilderAdapter myAd;

    protected abstract IntegerCoordinateSystem CreateCoodinateSystem();

    [SetUp]
    public void SetUp()
    {
      myBuilder = new CellConnectionBuilder();
      myIcs = CreateCoodinateSystem();
      myAd = myIcs.CreateAdapter(myBuilder);
    }

    [TearDown]
    public void TeamDown()
    {
      myBuilder = null;
      myIcs = null;
      myAd = null;
    }

    private class CellConnectionBuilder : ICellConnectionBuilder<IntegerCoordinate>
    {

      public void ConnectToMany(IntegerCoordinate cell, IEnumerable<IntegerCoordinate> v)
      {
        foreach (IntegerCoordinate t in v)
        {
          ConnectToOne(cell, t);
        }
      }

      public void ConnectToOne(IntegerCoordinate cell, IntegerCoordinate v)
      {
      }
    }
  }
}