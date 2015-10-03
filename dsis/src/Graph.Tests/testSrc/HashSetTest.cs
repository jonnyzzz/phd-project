/*
 * Created by: 
 * Created: 2 декабря 2006 г.
 */


using System.Collections.Generic;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class HashSetTest
  {
    [Test]
    public void Test_01()
    {
      Hashset<int> set = new Hashset<int>();

      for (int i = 0; i < 100; i++)
      {
        set.Add(i);
        Assert.AreEqual(set.Count, i + 1);
      }
    }

    [Test]
    public void Test_02()
    {
      Hashset<int> set = new Hashset<int>();

      for (int i = 0; i < 100; i++)
      {
        set.Add(i);
        set.Add(i);
        set.Add(i);
        set.Add(i);
        set.Add(i);
        set.Add(i);
        Assert.AreEqual(i + 1, set.Count);
      }
    }

    [Test]
    public void Test_03()
    {
      Hashset<string, string> set = new Hashset<string, string>();
      set.Add("foo");

      set.Add("foo");

      Assert.AreEqual(1, set.Count);
    }

    [Test]
    public void Test_04()
    {
      IntegerCoordinate c1 = new IntegerCoordinate(1);
      IntegerCoordinate c2 = new IntegerCoordinate(1);

      Hashset<IntegerCoordinate, IntegerCoordinate> set = new Hashset<IntegerCoordinate, IntegerCoordinate>();
      Assert.AreNotSame(c1, c2);

      set.Add(c1);
      set.Add(c2);

      Assert.AreEqual(1, set.Count);
    }

    [Test]
    public void Test_05()
    {
      IntegerCoordinate c1 = new IntegerCoordinate(1);
      IntegerCoordinate c2 = new IntegerCoordinate(1);

      Hashset<IntegerCoordinate> set = new Hashset<IntegerCoordinate>();
      Assert.AreNotSame(c1, c2);

      set.Add(c1);

      Assert.AreEqual(1, set.Count);
      set.AddIfNotReplace(ref c2);
      IEqualityComparer<IntegerCoordinate> cmp = EqualityComparerFactory<IntegerCoordinate>.GetComparer();
      Assert.IsTrue(cmp.Equals(c2, c1));
    }


    [Test]
    public void Test_06()
    {
      IntegerCoordinate2d c1 = new IntegerCoordinate2d(1,2);
      IntegerCoordinate2d c2 = new IntegerCoordinate2d(1,2);

      Hashset<IntegerCoordinate2d, IntegerCoordinate2d> set = new Hashset<IntegerCoordinate2d, IntegerCoordinate2d>();
      Assert.AreNotSame(c1, c2);

      set.Add(c1);
      set.Add(c2);

      Assert.AreEqual(1, set.Count);
    }


    [Test]
    public void Test_07()
    {
      IntegerCoordinate2d c1 = new IntegerCoordinate2d(1, 2);
      IntegerCoordinate2d c2 = new IntegerCoordinate2d(1, 1);
      IntegerCoordinate2d c3 = new IntegerCoordinate2d(2, 2);

      Hashset<IntegerCoordinate2d, IntegerCoordinate2d> set = new Hashset<IntegerCoordinate2d, IntegerCoordinate2d>();
      Assert.AreNotSame(c1, c2);

      set.Add(c1);
      set.Add(c2);
      set.Add(c3);

      Assert.AreEqual(3, set.Count);
    }
  }
}