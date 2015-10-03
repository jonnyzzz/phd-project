/*
 * Created by: 
 * Created: 6 ÿםגאנÿ 2007 ד.
 */

using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests.Generic;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests.Impl
{
  [TestFixture]
  public class SubdivisionTest : SubdivisionTestBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
    [Test]
    public void Test_01()
    {
      double[] l = { 1, 2, 3 };
      double[] r = { 3, 4 + 3, 5 + 7 };
      long[] g = { 5, 5, 6 };
      long[] d = { 5, 5, 6 };
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_02()
    {
      double[] l = { 1, 2 };
      double[] r = { 3, 4 + 3 };
      long[] g = { 1, 5 };
      long[] d = { 5, 7 };
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_03()
    {
      double[] l = { 1, 2, 3 };
      double[] r = { 3, 4 + 3, 5 + 7 };
      long[] g = { 1, 5, 6 };
      long[] d = { 5, 7, 6 };
      DoTest(l, r, g, d);
    }

    [Test]
    public void Test_04()
    {
      double[] l = { 0, 0 };
      double[] r = { 1, 1 };
      long[] g = { 5, 5 };
      long[] d = { 2, 2 };
      DoTest(l, r, g, d);
    }    
  }
}