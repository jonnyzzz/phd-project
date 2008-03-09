using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Tests.Generic;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests.Generated
{
  [TestFixture]
  public class IntegerCoordinate2dTest : IntegerCoordinatesBaseTest<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {

    [Test]
    public void Test_05()
    {
      DoEqTest(1, 7);
    }

    [Test]
    public void Test_06()
    {
      DoEqTest(1, 2);
    }

    [Test]
    public void Test_07()
    {
      DoEqTest(3, 2);
    }
  }
}