using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxMethod
{
  [TestFixture]
  public class BoxMethodIntegerCoordinateTest : BoxMethodBaseTest<IntegerCoordinateSystem, IntegerCoordinate>
  {
    [Test]
    public void Test_01()
    {
      DoTestOneDimensionAndAssert(0, 10, 10, 5, new BoxMethodSettings(0),
                                  delegate(double ins) { return ins; }, 5, 6);
    }    
  }
}