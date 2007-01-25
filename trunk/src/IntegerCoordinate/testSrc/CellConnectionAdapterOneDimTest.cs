using System.Collections.Generic;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class CellConnectionAdapterOneDimTest  : CellConnectionAdapterTestBase
  {
    private MockSystemSpace mySpace;
    private IntegerCoordinateSystem myIcs;

    [SetUp]
    public void SetUp()
    {
      mySpace = new MockSystemSpace(1, 0, 100, 500);
      myIcs = new IntegerCoordinateSystem(mySpace);
    }


    private void DoTest(double left, double right)
    {
      List<IntegerCoordinate> list = DoTest(myIcs, delegate(IntegerCoordinateCellImageBuilderAdapter ad)
                                                     {
                                                       IntegerCoordinate cs = myIcs.FromPoint(new double[] {1});
                                                       ad.ConnectCellToRect(cs, new double[] {left}, new double[] {right},
                                                                            new double[] {0});
                                                     });
      List<long> coords = list.ConvertAll<long>(delegate(IntegerCoordinate input) { return input.Coordinate[0]; });
      coords.Sort();
      long cnt = myIcs.FromPoint(new double[]{left}).Coordinate[0];
      foreach (long l in coords)
      {
        Assert.AreEqual(cnt++, l);        
      }
    }

    [Test]
    public void Test_01()
    {
      DoTest(0, 1);      
    }

    [Test]
    public void Test_02()
    {
      DoTest(0, 10);      
    }

    [Test]
    public void Test_03()
    {
      DoTest(10,20);
    }

    public void Test_04()
    {
      DoTest(0, 100);
    }
  }
}