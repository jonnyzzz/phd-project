using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class CellConnectionAdapterOneDimTest : CellConnectionAdapterTestBase
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
      List<long> coords = list.ConvertAll<long>(delegate(IntegerCoordinate input) { return input.GetCoordinate(0); });
      coords.Sort();
      Assert.IsTrue(coords.Count > 0, "Non empty result expected");

      IntegerCoordinate coor = myIcs.FromPoint(new double[] {left});
      Assert.IsNotNull(coor);
      long cnt = coor.GetCoordinate(0);
      foreach (long l in coords)
      {
        Assert.AreEqual(cnt++, l);
      }
      IntegerCoordinate rightC = myIcs.FromPoint(new double[] {right});
      Assert.IsNotNull(rightC);
      Assert.AreEqual(rightC.GetCoordinate(0), cnt - 1, "Right side");
    }

    private void DoTestPointToRect(double left, double right)
    {
      DoTestBuild(left, right, delegate(ICellConnectionBuilder<IntegerCoordinate> bld)
                                 {
                                   IRectProcessor<IntegerCoordinate> ps = myIcs.ProcessorFactory.CreateRectProcessor(0);
                                   IntegerCoordinate c = myIcs.Create(0);
                                   bld.ConnectToMany(c,
                                                     ps.ConnectCellToRect(new double[] {left},
                                                                                  new double[] {right}
                                                                                  ));
                                 });
    }

    private void DoTestOverlap(double left, double right, double pt, double procent)
    {
      DoTestBuild(left, right, delegate(ICellConnectionBuilder<IntegerCoordinate> bld)
                                 {
                                   IPointProcessor<IntegerCoordinate> ps = myIcs.ProcessorFactory.CreateOverlapedPointProcessor(new double[] {procent});
                                   IntegerCoordinate c = myIcs.FromPoint(new double[] {1});
                                   bld.ConnectToMany(c, ps.AddPoint(new double[] {pt}));
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
      DoTestPointToRect(10, 20);
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
      DoTestOverlap(myIcs.CellSize[0], myIcs.CellSize[0], myIcs.CellSize[0]*1.5, 0.1);
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
      DoTestOverlap(myIcs.CellSize[0]*(l - 1), myIcs.CellSize[0]*(l - 1), myIcs.CellSize[0]*l, 0.1);
    }
  }
}