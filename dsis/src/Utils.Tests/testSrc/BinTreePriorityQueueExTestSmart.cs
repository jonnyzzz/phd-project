using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Utils.Tests
{
  [TestFixture]
  public class BinTreePriorityQueueExTestSmart : BinTreePriorityQueueExTestBase 
  {
    [Test]
    public void Test_40()
    {
      DoSetTest(1);
    }

    [Test]
    public void Test_41()
    {
      DoSetTest(1, 2);
    }

    [Test]
    public void Test_42()
    {
      DoSetTest(1, -2);
    }

    [Test]
    public void Test_43()
    {
      DoSetTest(1, -2, 3);
    }

    [Test]
    public void Test_44()
    {
      DoSetTest(1, -2, 3, -6);
    }

    [Test]
    public void Test_44_1()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");

      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("b", -2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));
    }

    [Test]
    public void Test_45()
    {
      DoSetTest(1, -2, 3, -6, 7);
    }

    [Test]
    public void Test_46()
    {
      DoSetTest(1, 2, 3, 4, 56, 7, 8, 89, 6, 5345, 43);
    }

    [Test]
    public void Test_46_1()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AddNode(56, "e");

      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("b", 2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("d", 4));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("e", 56));
    }

    [Test]
    public void Test_46_2()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AddNode(56, "e");
      queue.AddNode(7, "f");

      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("b", 2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("d", 4));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("f", 7));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("e", 56));
    }

    [Test]
    public void Test_47()
    {
      DoSetTest(9, 8, 7, 6, 5, 4, 3, 2, 1);
    }

    [Test]
    public void Test_48()
    {
      DoSetTest(9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
    }

    [Test]
    public void Test_49()
    {
      DoSetTest(9, 8, 7, 99, 6, 5, 499, 3, 2, 1666, 0, 1, 2, 3, 4, 5, 6, 777, 7, 8, 9);
    }

    [Test]
    public void Test_50()
    {
      DoSetTest(9, 8, 7, 99, 6, 5, 499, 3, 2, 1666, 0, 1, 2, 3, 4, 5, 6, 777, 7, 8, 9);
    }

    [Test]
    public void Test_51()
    {
      DoSetTest(Random(55));
    }

    [Test]
    public void Test_52()
    {
      DoSetTest2(Random(155));
    }

    [Test]
    public void Test_53()
    {
      DoSetTest2(Random(2155));
    }

    [Test]
    public void Test_54()
    {
      DoSetTest2(Random(2355));
    }

    [Test]
    public void Test_56()
    {
      DoSetTest2(Random(32355));
    }

    [Test]
    public void Test_57()
    {
      DoSetTest2(Random(62355));
    }

    [Test]
    public void Test_58()
    {
      DoSetTest2(Random(128355));
    }

    [Test]
    public void Test_58_2()
    {
      DoSetTest2(Random(328355));
    }

    [Test]
    public void Test_59()
    {
      DoSetTest2(Random(355));
    }

    [Test]
    public void Test_60()
    {
      DoSetTest2(Random(555));
    }


    [Test]
    public void Test_70()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      object n = queue.AddNode(4, "d");

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));
      queue.Remove(n);

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("b", 2));
      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));
    }

    [Test]
    public void Test_71()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      object n = queue.AddNode(4, "d");

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));
      queue.Remove(n);

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("b", 2));
      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));
    }

    [Test]
    public void Test_72()
    {
      queue.AddNode(1, "a");
      object n1 = queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      object n2 = queue.AddNode(4, "d");

      Assert.AreEqual(queue.ExtractMin(), Pair.Of("a", 1));

      queue.Remove(n1);
      queue.Remove(n2);
      Assert.AreEqual(queue.ExtractMin(), Pair.Of("c", 3));
    }

    [Test]
    public void Test_73()
    {
      DoSetTest3(1, 2, 3, 4, 5);
    }

    [Test]
    public void Test_73_1()
    {
      int[] data = { 1, 2, 3, 4, 5 };

      var listData = new Dictionary<int, object>();
      for (int i = 0; i < data.Length; i++)
      {
        int v = data[i];
        listData.Add(v, queue.AddNode(v, v.ToString()));
      }

      queue.Debug();
      for (int j = 0; j < data.Length; j++)
      {
        Console.Out.WriteLine("data[j] = {0}", data[j]);
        queue.Remove(listData[data[j]]);
        listData.Remove(data[j]);
        queue.Debug();
      }

      var keys = new List<int>(listData.Keys);
      keys.Sort();

      foreach (int key in keys)
      {
        Assert.AreEqual(queue.ExtractMin().Second, key);
      }

      try
      {
        queue.ExtractMin();
        Assert.Fail("No elements expected!");
      }
      catch (ArgumentException)
      {
      }

      Assert.AreEqual(queue.Count, 0);
    }

    [Test]
    public void Test_73_2()
    {
      int[] data = { 1, 2, 3, 4, 5 };

      var listData = new Dictionary<int, object>();
      for (int i = 0; i < data.Length; i++)
      {
        int v = data[i];
        listData.Add(v, queue.AddNode(v, v.ToString()));
      }

      queue.Debug();
      for (int j = 0; j < data.Length; j++)
      {
        if (j % 2 == 0)
        {
          Console.Out.WriteLine("data[j] = {0}", data[j]);
          queue.Remove(listData[data[j]]);
          listData.Remove(data[j]);
          queue.Debug();
        }
      }

      var keys = new List<int>(listData.Keys);
      keys.Sort();

      foreach (int key in keys)
      {
        Assert.AreEqual(queue.ExtractMin().Second, key);
      }

      try
      {
        queue.ExtractMin();
        Assert.Fail("No elements expected!");
      }
      catch (ArgumentException)
      {
      }

      Assert.AreEqual(queue.Count, 0);
    }

    [Test]
    public void Test_74()
    {
      DoSetTest3(1, 2, 3, 4, 5, 6, 7, 8, 9);
    }

    [Test]
    public void Test_75()
    {
      DoSetTest3(9, 8, 7, 6);
    }

    [Test]
    public void Test_76()
    {
      DoSetTest3(9, 8, 7, 6, 5, 4, 3, 2, 1);
    }

    [Test]
    public void Test_77()
    {
      DoSetTest3(Random2(10));
    }

    [Test]
    public void Test_78()
    {
      DoSetTest3(Random2(20));
    }

    [Test]
    public void Test_79()
    {
      DoSetTest3(Random2(80));
    }

    [Test]
    public void Test_80()
    {
      DoSetTest3(Random2(512));
    }

    [Test]
    public void Test_81()
    {
      DoSetTest3(Random2(1024));
    }

    [Test]
    public void Test_82()
    {
      DoSetTest3(Random2(4096));
    }
  }
}