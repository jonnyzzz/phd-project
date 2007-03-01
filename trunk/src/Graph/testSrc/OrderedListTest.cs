using System.Collections.Generic;
using DSIS.Graph.Util;
using NUnit.Framework;

namespace DSIS.Graph
{
  [TestFixture]
  public class OrderedListTest
  {
    private OrderedList<int> myList = null;

    [SetUp]
    public void SetUp()
    {
      myList = new OrderedList<int>();
    }

    [TearDown]
    public void TearDown()
    {
      myList = null;
    }

    private static void AssertCollection<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
      List<T> exp = new List<T>(expected);
      List<T> act = new List<T>(actual);

      Assert.AreEqual(exp.Count, act.Count, "Collection size assert");

      for (int i = 0; i < exp.Count; i++)
      {
        Assert.AreEqual(exp[i], act[i], "Collection element at index {0}", i);
      }
    }

    [Test]
    public void Test_01()
    {
      myList.Add(0);
      int count = new List<int>(myList.Find(0)).Count;
      Assert.AreEqual(1, count);
    }

    [Test]
    public void Test_02()
    {
      myList.Add(100);
      myList.Add(10);
      myList.Add(1000);

      int? v = null;
      foreach (int i in myList.Elements)
      {
        Assert.IsTrue(v == null || v < i);
        v = i;
      }
    }

    [Test]
    public void Test_03()
    {
      myList.Add(100);
      myList.Add(10);
      myList.Add(1000);
      IEnumerable<int> l = myList.Find(1000);

      int[] myAssert = {10, 100, 1000};
      AssertCollection(myAssert, l);
    }

    [Test]
    public void Test_04()
    {
      myList.Add(100);
      myList.Add(100);
      myList.Add(100);
      myList.Add(10);
      myList.Add(10);
      myList.Add(10);
      myList.Add(10);
      myList.Add(1000);
      myList.Add(1000);
      myList.Add(1000);
      myList.Add(1000);

      int? v = null;
      foreach (int i in myList.Elements)
      {
        Assert.IsTrue(v == null || v < i);
        v = i;
      }
    }

    [Test]
    public void Test_05()
    {
      myList.Add(100);
      myList.Add(100);
      myList.Add(100);
      myList.Add(100);
      myList.Add(10);
      myList.Add(10);
      myList.Add(10);
      myList.Add(10);
      myList.Add(10);

      List<int> ass = new List<int>();
      ass.Add(10);
      ass.Add(100);
      ass.Add(1000);
      for (int i = 0; i < 100; i++)
      {
        myList.Add(i + 4);
        if (!ass.Contains(i + 4))
          ass.Add(i + 4);
      }

      ass.Sort();

      myList.Add(1000);
      myList.Add(1000);
      myList.Add(1000);
      myList.Add(1000);
      IEnumerable<int> l = myList.Find(1000);
      AssertCollection(ass, l);
    }

    [Test]
    public void Test_06()
    {
      for (int i = 0; i < 100; i++)
      {
        myList.Add(100 - i);
      }

      List<int> l = new List<int>(myList.Find(100));
      Assert.AreEqual(100, l.Count);
    }

    [Test]
    public void Test_07()
    {
      for (int i = 0; i < 100; i++)
      {
        myList.Add(100 - i);
      }

      List<int> l = new List<int>(myList.Find(1000));
      Assert.AreEqual(100, l.Count);
    }

    [Test]
    public void Test_08()
    {
      OrderedList<int> l = new OrderedList<int>();
      Assert.IsTrue(l.IsLess(0));
    }

    public void Test_09()
    {
      OrderedList<int> l = new OrderedList<int>();
      l.Add(1);
      Assert.IsFalse(l.IsLess(2));
    }
  }
}