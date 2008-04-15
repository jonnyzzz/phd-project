using System;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests.Intersections
{
  [TestFixture]
  public class PointIntegerCoordinateIntersectionTest :  PointIntegerCoordinateIntersectionTestBase
  {
    //todo: Build function according to the Graph
    private static double Id(double x)
    {
      if (Math.Abs(x - 1) < 1e-4)
        return 2;
      if (Math.Abs(x - 2) < 1e-4)
        return 1;
      return x;
    }


    [Test]
    public void DoTest_01()
    {
      DoTest(Id, 3, 0, n(1, 2), n(2, 1));
    }
    
  }
}