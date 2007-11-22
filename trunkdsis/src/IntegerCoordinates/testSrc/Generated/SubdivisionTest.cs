using DSIS.IntegerCoordinates.Generic;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Generated
{
  [TestFixture]
  public class SubdivisionTest : SubdivisionTestBase<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {

    [Test]
    public void Test_02()
    {
      double[] l = { 1, 2 };
      double[] r = { 3, 4 + 3 };
      long[] g = { 1, 5 };
      long[] d = { 5, 7 };
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_04()
    {
      double[] l = { 0, 0 };
      double[] r = { 1, 1 };
      long[] g = { 5, 5 };
      long[] d = { 2, 2 };
      DoTest(l, r, g, d);
    }
    
  }
}