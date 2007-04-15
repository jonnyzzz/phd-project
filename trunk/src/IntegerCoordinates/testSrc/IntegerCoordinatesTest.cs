using System;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Test
{
  [TestFixture]
  public class IntegerCoordinatesTest
  {
    private static void DoEqTest(params long[] l)
    {
      IntegerCoordinate ic = new IntegerCoordinate(l);
      IntegerCoordinate ic2 = new IntegerCoordinate(l);
      IntegerCoordinate ic3 = new IntegerCoordinate((long[]) l.Clone());

      Hashset<IntegerCoordinate> hs = new Hashset<IntegerCoordinate>();
      hs.Add(ic);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));

      hs.Clear();
      hs.Add(ic3);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));

      hs.Clear();
      hs.Add(ic2);

      Assert.IsTrue(hs.Contains(ic));
      Assert.IsTrue(hs.Contains(ic2));
      Assert.IsTrue(hs.Contains(ic3));
    }

    [Test]
    [ExpectedException(typeof (NullReferenceException))]
    public void Test_01()
    {
      new IntegerCoordinate(null).GetHashCode();
    }

    [Test]
    [ExpectedException(typeof (IndexOutOfRangeException))]
    public void Test_02()
    {
      IntegerCoordinate c1 = new IntegerCoordinate(new long[] {1, 2, 3});
      IntegerCoordinate c2 = new IntegerCoordinate(new long[] {1, 2});

      Assert.AreNotEqual(c1, c2);
      Assert.IsFalse(c1.Comparer.Equals(c1, c2));
    }

    [Test]
    public void Test_03()
    {
      IntegerCoordinate c = new IntegerCoordinate(new long[] {1});
      Assert.IsTrue(c.Comparer.GetHashCode() >= 0);
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