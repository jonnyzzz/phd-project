using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class CellConnectionBuilder2DPerformanceTest : CellConnectionBuilderPerformanceTestBase
  {
    protected override IntegerCoordinateSystem CreateCoodinateSystem()
    {
      return
        new IntegerCoordinateSystem(
          new MockSystemSpace(2, new double[] {0, 0}, new double[] {1, 1}, new long[] {100, 100}));
    }


    [Test]
    public void Test_Overlapping()
    {
      double[] eps = new double[]{0.2, 0.2};
      double[] point = new double[] { 1, 1 };
      IntegerCoordinate coordinate = new IntegerCoordinate(1, 1);
      for (int i = 0; i < 30000; i++)
      {
        point[0] += myIcs.CellSizeHalf[0]*.79;
        point[1] += myIcs.CellSizeHalf[1]*.76;
        myAd.AddPointWithOverlapping(coordinate, point, eps);
      }
    }

    [Test]
    public void Test_rect()
    {
      IntegerCoordinate coordinate = new IntegerCoordinate(1, 1);
      double[] right = new double[]{20,30};
      double[] left = new double[]{1,1};
      double[] eps = new double[]{0.1, 0.1};
      for (int i = 0; i < 30000; i++)
        myAd.ConnectCellToRect(coordinate, left, right, eps);
    }
    
    [Test]
    public void Test_radius()
    {
      IntegerCoordinate coordinate = new IntegerCoordinate(1, 1);
      double[] left = new double[]{1,1};
      double[] eps = new double[]{2.1, 5.1};
      for (int i = 0; i < 300; i++)
        myAd.ConnectCellToPointWithRadius(coordinate, left, eps);
    }
  }
}