/*
 * Created by: 
 * Created: 6 ÿםגאנÿ 2007 ד.
 */

using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class SubdivisionTest
  {
    private static void DoTest(double[] l, double[] r, long[] g, long[] div)
    {
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(new MockSystemSpace(l.Length, l, r, g));
      List<IntegerCoordinate> coords = new List<IntegerCoordinate>(ics.InitialSubdivision);

      ICellCoordinateSystemConverter<IntegerCoordinate, IntegerCoordinate> converter = ics.Subdivide(div);

      Hashset<IntegerCoordinate> ass = new Hashset<IntegerCoordinate>();
      foreach (IntegerCoordinate coord in coords)
      {
        try
        {
          foreach (IntegerCoordinate coordinate in converter.Subdivide(coord))
          {
            try
            {
              Assert.IsFalse(ass.Contains(coordinate));
            }
            catch
            {
              Console.Out.WriteLine("coordinate = {0}", coordinate);
              throw;
            }
            ass.Add(coordinate);
          }
        }
        catch
        {
          Console.Out.WriteLine("coord = {0}", coord);
          throw;
        }
      }

      long m = 1;
      foreach (long ll in div)
      {
        m *= ll;
      }

      long n = 1;
      foreach (long l1 in g)
      {
        n *= l1;
      }

      Assert.AreEqual(n*m, ass.Count);
    }

    [Test]
    public void Test_01()
    {
      double[] l = {1, 2, 3};
      double[] r = {3, 4 + 3, 5 + 7};
      long[] g = {5, 5, 6};
      long[] d = {5, 5, 6};
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_02()
    {
      double[] l = {1, 2};
      double[] r = {3, 4 + 3};
      long[] g = {1, 5};
      long[] d = {5, 7};
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_03()
    {
      double[] l = {1, 2, 3};
      double[] r = {3, 4 + 3, 5 + 7};
      long[] g = {1, 5, 6};
      long[] d = {5, 7, 6};
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_04()
    {
      double[] l = {0, 0};
      double[] r = {1, 1};
      long[] g = {5, 5};
      long[] d = {2, 2};
      DoTest(l, r, g, d);
    }
  }
}