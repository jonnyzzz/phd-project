using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  [TestFixture]
  public class BoxAdaptiveMethodIntegerCoordinateTest : BoxAdaptiveMethodBaseTest<IntegerCoordinateSystem, IntegerCoordinate>
  {
    [Test]
    public void Test_01()
    {
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
        100, 0.1);
      DoTestOneDimensionAndAssert(0, 10, 10,
                                  5, stategy,
                                  delegate(double ins) { return ins; }, 4, 6);
    }
  }
}