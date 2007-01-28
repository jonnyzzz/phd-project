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

    private void DoTestBuild(double left, double right, DoBuild bld)
    {
      List<IntegerCoordinate> list = DoTest(myIcs, bld);
      List<long> coords = list.ConvertAll<long>(delegate(IntegerCoordinate input)
                                                  {
                                                    return input.Coordinate[0];
                                                  });
      coords.Sort();
      Assert.IsTrue(coords.Count > 0, "Non empty result expected");

      IntegerCoordinate coor = myIcs.FromPoint(new double[] { left });
      Assert.IsNotNull(coor);
      long cnt = coor.Coordinate[0];
      foreach (long l in coords)
      {
        Assert.AreEqual(cnt++, l);
      }
      IntegerCoordinate rightC = myIcs.FromPoint(new double[] {right});
      Assert.IsNotNull(rightC);
      Assert.AreEqual(rightC.Coordinate[0], cnt - 1, "Right side");
    }

    private void DoTestPointToRect(double left, double right)
    {
      DoTestBuild(left, right, delegate(IntegerCoordinateCellImageBuilderAdapter ad)
                                 {
                                   IntegerCoordinate cs = myIcs.FromPoint(new double[] { 1 });
                                   ad.ConnectCellToRect(cs, new double[] { left}, new double[] { right },
                                                        new double[] { 0 });                                   
                                 });
    }

    private void DoTestOverlap(double left, double right, double pt, double procent)
    {
      DoTestBuild(left, right, delegate(IntegerCoordinateCellImageBuilderAdapter ad)
                                 {
                                   IntegerCoordinate c = myIcs.FromPoint(new double[]{1});
                                   ad.AddPointWithOverlapping(c, new double[]{pt}, new double[]{procent});
                                 });
    }

    [Test]
    public void Test_01()
    {
      DoTestPointToRect(0, 1);      
    }

    [Test]
    public void Test_02()
    {
      DoTestPointToRect(0, 10);      
    }

    [Test]
    public void Test_03()
    {
      DoTestPointToRect(10,20);
    }

    [Test]
    public void Test_04()
    {
      DoTestPointToRect(0, 100);
    }

    [Test]
    public void Test_05()
    {
      DoTestOverlap(0, 0, 0, 0.1);
    }

    [Test]
    public void Test_06()
    {
      DoTestOverlap(myIcs.CellSize[0], myIcs.CellSize[0], myIcs.CellSize[0] * 1.5, 0.1);
    }

    [Test]
    public void Test_07()
    {
      DoTestOverlap(myIcs.CellSize[0], myIcs.CellSize[0]*2, myIcs.CellSize[0]*2, 0.1);
    }

    [Test]
    public void Test_08()
    {
      long l = myIcs.Subdivision[0];
      DoTestOverlap(myIcs.CellSize[0]*(l-1), myIcs.CellSize[0]*(l-1), myIcs.CellSize[0] * l, 0.1);
    }
  }
}