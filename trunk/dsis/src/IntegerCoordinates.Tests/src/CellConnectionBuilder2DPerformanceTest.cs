using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests
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
      double[] eps = new double[] {0.2, 0.2};
      double[] point = new double[] {1, 1};
      IPointProcessor<IntegerCoordinate> ps = myIcs.ProcessorFactory.CreateOverlapedPointProcessor(eps);
      for (int i = 0; i < 30000; i++)
      {
        point[0] += myIcs.CellSizeHalf[0]*.79;
        point[1] += myIcs.CellSizeHalf[1]*.76;        
        Iterate(ps.AddPoint(point));
      }
    }

    [Test]
    public void Test_radius()
    {
      IRadiusProcessor<IntegerCoordinate> pr = myIcs.CreateRadiusProcessor();
      double[] left = new double[] {1, 1};
      double[] eps = new double[] {2.1, 5.1};
      for (int i = 0; i < 300; i++)
        Iterate(pr.ConnectCellToRadius(left, eps));
    }

    [Test]
    public void Test_rect()
    {
      double[] right = new double[] {20, 30};
      double[] left = new double[] {1, 1};
      double[] eps = new double[] {0.1, 0.1};
      IRectProcessor<IntegerCoordinate> pr = myIcs.ProcessorFactory.CreateRectProcessor(eps);
      for (int i = 0; i < 30000; i++)
        Iterate(pr.ConnectCellToRect(left, right));
    }
  }
}