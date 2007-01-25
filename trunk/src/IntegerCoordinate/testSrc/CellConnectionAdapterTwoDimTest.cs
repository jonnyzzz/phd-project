using System;
using System.Collections.Generic;
using System.Text;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Util;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class CellConnectionAdapterTwoDimTest : CellConnectionAdapterTestBase
  {

    private static string DoTest(IntegerCoordinateSystem ics, List<IntegerCoordinate> list)
    {
      Hashset<IntegerCoordinate> hs = new Hashset<IntegerCoordinate>();
      hs.AddRange(list);

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("-------------------");
      for (long lx = 0; lx<ics.Subdivision[0]; lx++)
      {
        for (long ly = 0; ly < ics.Subdivision[1]; ly++)
        {
          if (hs.Contains(new IntegerCoordinate(lx, ly)))
          {
            sb.AppendFormat("x");
          } else
          {
            sb.AppendFormat(".");
          }
        }
        sb.AppendLine();
      }
      sb.AppendLine("-------------------");

      return sb.ToString();
    }

    private static void DoTest(double[] left, double[] right, string assert)
    {
      double[] sleft = {0, 0};
      double[] sright = {10, 10};
      long[] sgrid = {10, 10};
      double[] eps = { 0, 0 };
      
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(new MockSystemSpace(2, sleft, sright, sgrid));
      List<IntegerCoordinate> data = DoTest(ics,
                                            delegate(IntegerCoordinateCellImageBuilderAdapter ad)
                                              {
                                                ad.ConnectCellToRect(null, left, right, eps);
                                              });

      string s = DoTest(ics, data);
      try
      {
        Assert.AreEqual(assert, s);
      } catch
      {
        Console.Out.WriteLine("s = \r\n{0}", s);
        throw;
      }
    }   
 
    [Test]
    public void Test_01()
    {
      DoTest(new double[] { 0, 0 }, new double[] { 10, 10 },
@"-------------------
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
xxxxxxxxxx
-------------------
");
    }


    [Test]
    public void Test_02()
    {
      DoTest(new double[] { 1, 0 }, new double[] { 2, 2 },
@"-------------------
..........
xxx.......
xxx.......
..........
..........
..........
..........
..........
..........
..........
-------------------
");
    }

    [Test]
    public void Test_03()
    {
      DoTest(new double[] { 0.01, 0.02 }, new double[] { 0.01, 0.02 },
@"-------------------
x.........
..........
..........
..........
..........
..........
..........
..........
..........
..........
-------------------
");
    }

  }
}