using System;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests.Generic;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests.Impl
{
  [TestFixture]
  public class IntegerCoordinatesTest : IntegerCoordinatesBaseTest<IntegerCoordinateSystem,IntegerCoordinate>
  {
    [Test]
    [ExpectedException(typeof(NullReferenceException))]
    public void Test_01()
    {
      IntegerCoordinateEqualityComparer.INSTANCE.GetHashCode(new IntegerCoordinate(null));
    }

    [Test]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Test_02()
    {
      IntegerCoordinate c1 = new IntegerCoordinate(new long[] { 1, 2, 3 });
      IntegerCoordinate c2 = new IntegerCoordinate(new long[] { 1, 2 });

      Assert.IsFalse(c1.Comparer.Equals(c1, c2));
      Assert.IsFalse(c1.Comparer.Equals(c1, c2));
    }

    [Test]
    public void Test_03()
    {
      IntegerCoordinate c = new IntegerCoordinate(new long[] { 1 });
      Assert.IsTrue(c.Comparer.GetHashCode(c) >= 0);
    }


    [Test]
    public void Test_05()
    {
      DoEqTest(1);
    }

    [Test]
    public void Test_06()
    {
      DoEqTest(1, 2);
    }

    [Test]
    public void Test_07()
    {
      DoEqTest(3, 2);
    }

    [Test]
    public void Test_08()
    {
      DoEqTest(3, 2, 5, 7, 1111, 99999999L);
    }

    [Test]
    public void Test_09()
    {
      DoEqTest(3, 0, 0, 0, 11, 0699999999L);
    }
  }
}