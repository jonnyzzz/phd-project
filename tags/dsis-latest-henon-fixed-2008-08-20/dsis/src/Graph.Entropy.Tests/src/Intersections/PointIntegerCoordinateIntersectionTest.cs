using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests.Intersections
{
  [TestFixture]
  public class PointIntegerCoordinateIntersectionTest :  PointIntegerCoordinateIntersectionTestBase
  {
    [Test]
    public void DoTest_01_one()
    {
      DoTest(ConnectionType.One, 0, n(1, 2, 0.5), n(2, 1, 0.5));
    }

    [Test]
    public void DoTest_01_many()
    {
      DoTest(ConnectionType.Many, 0, n(1, 2,0.5), n(2, 1, 0.5));
    }
    
    [Test]
    public void DoTest_02_many_loop()
    {
      DoTest(ConnectionType.Many, 0, n(1, 2), n(2, 3), n(3, 4), n(4, 5), n(5, 1));
    }
    
    [Test]
    public void DoTest_02_many_2loop()
    {
      DoTest(ConnectionType.Many, 0, n(1, 2), n(2, 3), n(3, 4), n(4, 5), n(5, 1), n(7,8), n(8,9), n(9,10), n(10, 7));
    }

    [Test, Ignore("By design")]
    public void DoTest_02_many_2loop_i()
    {
      DoTest(ConnectionType.Many, 0, n(1, 2), n(2, 3), n(3, 4), n(4, 5), n(5, 7), n(7,1), n(7,8), n(8,9), n(9,10), n(10, 7));
    }

    [Test, Ignore("By design")]
    public void DoTest_02_many()
    {
      DoTest(ConnectionType.Many, 0, n(1, 5), n(2, 5), n(3, 5), n(4, 5), n(5,5), n(5, 1), n(1,2), n(2,3), n(3,4));
    }
    
    [Test, Ignore("By design")]
    public void DoTest_02_one()
    {
      DoTest(ConnectionType.Many, 0, n(1, 5), n(2, 5), n(3, 5), n(4, 5), n(5,5));
    }
    
  }
}