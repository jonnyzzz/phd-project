using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Processor;
using DSIS.Core.Util;
using NUnit.Framework;

namespace DSIS.Core.Tests.Processor
{
  [TestFixture]
  public class BufferedThreadedCountEnumerableTest
  {
    private static CountEnumerable<int> MakeList(int count)
    {
      var list = new List<int>();
      for (int i = 0; i < count; i++)
      {
        list.Add(i);
      }
      return new CountEnumerable<int>(list, list.Count);
    }

    private static void DoTest(int count, int buffer)
    {
      var be = new BufferedThreadedCountEnumerable<int>(new Mutex(), MakeList(count), buffer);

      int i = 0;
      foreach (int i1 in be)
      {
        Assert.AreEqual(i++, i1, "items are not equal");
      }
      Assert.AreEqual(count, i, "collection size");
    }

    [Test]
    public void Test_01()
    {
      DoTest(1, 100);
    }

    [Test]
    public void Test_02()
    {
      DoTest(100, 100);
    }

    [Test]
    public void Test_03()
    {
      DoTest(99, 100);
    }

    [Test]
    public void Test_04()
    {
      DoTest(101, 100);
    }

    [Test]
    public void Test_05()
    {
      DoTest(201, 100);
    }

    [Test]
    public void Test_06()
    {
      DoTest(199, 100);
    }

    [Test]
    public void Test_07()
    {
      DoTest(200, 100);
    }
  }
}