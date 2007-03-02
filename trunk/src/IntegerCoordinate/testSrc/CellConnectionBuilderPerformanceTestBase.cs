using DSIS.Core.Builders;
using DSIS.Core.Mock;
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
      myBuilder = new MockCellConnectionBuilder<IntegerCoordinate>();
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
  }
}