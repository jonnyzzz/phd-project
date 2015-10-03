using System;
using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Utils;
using NUnit.Framework;
using System.Linq;

namespace DSIS.IntegerCoordinates.Tests.Generic
{
  public abstract class CellConnectionAdapterOneDimBaseTest<T,Q> : CellConnectionAdapterTestBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    [SetUp]
    public void SetUp()
    {
      mySpace = new MockSystemSpace(1, 0, 100, 500);
      myIcs = CoordinateSystem();
    }

    [Used]
    protected virtual T CoordinateSystem()
    {
      return IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(mySpace);
    }

    private void DoTestBuild(double left, double right, DoBuild bld)
    {
      List<Q> list = DoTest(myIcs, bld);
      List<long> coords = list.ConvertAll(input => input.GetCoordinate(0));
      coords.Sort();
      Assert.IsTrue(coords.Count > 0, "Non empty result expected");

      Q coor = myIcs.FromPoint(new[] {left});
      Assert.IsNotNull(coor);
      Assert.IsFalse(myIcs.IsNull(coor));

      long cnt = coor.GetCoordinate(0);
      foreach (long l in coords)
      {
        Assert.AreEqual(cnt++, l);
      }

      Q rightC = myIcs.FromPoint(new[] {right});
      Assert.IsNotNull(rightC);
      Assert.IsFalse(myIcs.IsNull(rightC));

      Console.Out.WriteLine("rightC = {0}", rightC);
      Console.Out.WriteLine("cnt = {0}", cnt);

      Assert.AreEqual(Math.Min(cnt - 1, myIcs.Subdivision[0]-1), rightC.GetCoordinate(0), "Right side");
    }

    private void DoTestPointToRect(double left, double right)
    {
      DoTestBuild(left, right, delegate(ICellConnectionBuilder<Q> bld)
                                 {
                                   IRectProcessor<Q> ps = myIcs.ProcessorFactory.CreateRectProcessor(0);
                                   Q c = myIcs.Create(0);
                                   bld.ConnectToMany(c,
                                                     ps.ConnectCellToRect(new[] {left},
                                                                          new[] {right}
                                                       ));
                                 });
    }

    private void DoTestOverlap(double left, double right, double pt, double procent)
    {
      DoTestBuild(left, right, delegate(ICellConnectionBuilder<Q> bld)
                                 {
                                   IPointProcessor<Q> ps = myIcs.ProcessorFactory.CreateOverlapedPointProcessor(new[] {procent});
                                   Q c = myIcs.FromPoint(new [] {1.0});
                                   bld.ConnectToMany(c, ps.AddPoint(new[] {pt}));
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
      DoTestPointToRect(0, 99);
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

    [Test]
    public void Test_LeftBound()
    {
      var pt = myIcs.FromPoint(myIcs.SystemSpace.AreaLeftPoint);
      Assert.IsFalse(myIcs.IsNull(pt));
      Assert.AreEqual(0, pt.GetCoordinate(0));
    }

    [Test]
    public void Test_RightBound()
    {
      var pt = myIcs.FromPoint(myIcs.SystemSpace.AreaRightPoint);
      Assert.IsFalse(myIcs.IsNull(pt));
      Assert.AreEqual(myIcs.Subdivision[0], pt.GetCoordinate(0));
    }

    [Test]
    public void Test_AllRange()
    {
      var p = myIcs.ProcessorFactory.CreateRectProcessor(myIcs.CellSizeHalf);

      var list = p.ConnectCellToRect((-1.0e22).Fill(1), 1.0e22.Fill(1)).Select(x=>x.GetCoordinate(0)).ToList();
      for(long i = 0; i < myIcs.Subdivision[0]; i++)
      {
        Assert.IsTrue(list.Contains(i), "Should contain " + i);
        list.Remove(i);
      }
      Assert.IsTrue(list.Count == 0, "Shoud be empty, but was " + list.JoinString(x => x.ToString(), ", "));
    }

    [Test]
    public void Test_LeftRange()
    {
      var p = myIcs.ProcessorFactory.CreateRectProcessor(myIcs.CellSizeHalf);

      var mid = ((mySpace.AreaLeftPoint[0] + mySpace.AreaRightPoint[0])/2).Fill(1);
      var list = p.ConnectCellToRect((-1.0e22).Fill(1), mid).Select(x=>x.GetCoordinate(0)).ToList();

      var fromPoint = myIcs.FromPoint(mid);
      Assert.IsFalse(myIcs.IsNull(fromPoint), "mid point should be non-null");
      Assert.IsNotNull(fromPoint, "mid point should be non-null");

      var midP = fromPoint.GetCoordinate(0)+1;

      for(long i = 0; i < midP; i++)
      {
        Assert.IsTrue(list.Contains(i), "Should contain " + i);
        list.Remove(i);
      }
      Assert.IsTrue(list.Count == 0, "Shoud be empty, but was " + list.JoinString(x => x.ToString(), ", "));
    }

    [Test]
    public void Test_RightRange()
    {
      var p = myIcs.ProcessorFactory.CreateRectProcessor(myIcs.CellSizeHalf);

      var mid = ((mySpace.AreaLeftPoint[0] + mySpace.AreaRightPoint[0])/2).Fill(1);
      var fromPoint = myIcs.FromPoint(mid);
      Assert.IsFalse(myIcs.IsNull(fromPoint), "mid point should be non-null");
      Assert.IsNotNull(fromPoint, "mid point should be non-null");

      var midP = fromPoint.GetCoordinate(0)-1;

      var list = p.ConnectCellToRect(mid, 1.0e22.Fill(1)).Select(x=>x.GetCoordinate(0)).ToList();
      for(long i = midP; i < myIcs.Subdivision[0]; i++)
      {
        Assert.IsTrue(list.Contains(i), "Should contain "  + i);
        list.Remove(i);
      }
      Assert.IsTrue(list.Count == 0, "Shoud be empty, but was " + list.JoinString(x=>x.ToString(), ", "));
    }
  }
}