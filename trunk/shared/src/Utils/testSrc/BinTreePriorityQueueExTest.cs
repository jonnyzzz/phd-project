using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class BinTreePriorityQueueExTest
  {
    private Queue queue;

    [SetUp]
    public void SetUp()
    {
      queue = new Queue();
    }

    [Test]
    public void Test_01()
    {
      Assert.AreEqual(null, queue.Min);
    }

    [Test]
    public void Test_02()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual("a", queue.Min);
    }

    [Test]
    public void Test_03()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      Assert.AreEqual("a", queue.Min);
    }

    [Test]
    public void Test_04()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      Assert.AreEqual("b", queue.Min);
    }

    [Test]
    public void Test_05()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      Assert.AreEqual("a", queue.Min);
    }


    [Test]
    public void Test_06()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      Assert.AreEqual("c", queue.Min);
    }

    [Test]
    public void Test_07()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      Assert.AreEqual("c", queue.Min);
    }

    [Test]
    public void Test_08()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AddNode(4, "d");
      queue.AddNode(-4, "e");
      Assert.AreEqual("e", queue.Min);
    }

    [Test, ExpectedException(typeof (ArgumentException))]
    public void Test_11()
    {
      queue.ExtractMin();
    }

    [Test]
    public void Test_12()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
    }

    [Test, ExpectedException(typeof (ArgumentException))]
    public void Test_13()
    {
      queue.AddNode(1, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }

    [Test]
    public void Test_14()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
    }

    [Test, ExpectedException(typeof (ArgumentException))]
    public void Test_15()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "a");
      Assert.AreEqual(1, queue.ExtractMin().Second);
      queue.ExtractMin();
      queue.ExtractMin();
    }

    [Test]
    public void Test_20()
    {
      queue.AssertConsolidateGroup("[null]");
    }

    [Test]
    public void Test_21()
    {
      queue.AddNode(1, "a");
      queue.AssertConsolidateGroup("0. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_22()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AssertConsolidateGroup("<null>", "|", "0. a(1)", "1. b(2)", "|", "<null>", "|");
    }

    [Test]
    public void Test_23()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AssertConsolidateGroup("0. b(2)", "|", "0. c(-3)", "1. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_24()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AssertConsolidateGroup("<null>", "|", "0. b(-2)", "1. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_25()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AssertConsolidateGroup("0. c(3)", "|", "0. b(-2)", "1. a(1)", "|", "<null>", "|");
    }

    [Test]
    public void Test_26()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AssertConsolidateGroup("<null>", "|", "<null>", "|", "0. b(-2)", "1. a(1)", "1. c(3)", "2. d(4)", "|",
                                   "<null>", "|");
    }

    [Test]
    public void Test_30()
    {
      queue.AssertConsolidate("<null>");
    }

    [Test]
    public void Test_31()
    {
      queue.AddNode(1, "a");
      queue.AssertConsolidate("0. a(1)");
    }

    [Test]
    public void Test_32()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AssertConsolidate("0. a(1)", "1. b(2)");
    }

    [Test]
    public void Test_33()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(-3, "c");
      queue.AssertConsolidate("0. c(-3)", "1. a(1)", "|", "0. b(2)");
    }

    [Test]
    public void Test_34()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)");
    }

    [Test]
    public void Test_35()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)", "|", "0. c(3)");
    }

    [Test]
    public void Test_36()
    {
      queue.AddNode(1, "a");
      queue.AddNode(-2, "b");
      queue.AddNode(3, "c");
      queue.AddNode(4, "d");
      queue.AssertConsolidate("0. b(-2)", "1. a(1)", "1. c(3)", "2. d(4)");
    }

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

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("b", -2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));
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

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("b", 2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("d", 4));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("e", 56));
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

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("b", 2));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("d", 4));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("f", 7));

      Console.Out.WriteLine("---------");
      Console.Out.WriteLine(queue.Dump());

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("e", 56));
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

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));
      queue.Remove(n);

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("b", 2));
      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));
    }

    [Test]
    public void Test_71()
    {
      queue.AddNode(1, "a");
      queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      object n = queue.AddNode(4, "d");

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));
      queue.Remove(n);

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("b", 2));
      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));
    }

    [Test]
    public void Test_72()
    {
      queue.AddNode(1, "a");
      object n1 = queue.AddNode(2, "b");
      queue.AddNode(3, "c");
      object n2 = queue.AddNode(4, "d");

      Assert.AreEqual(queue.ExtractMin(), Pair.Create("a", 1));

      queue.Remove(n1);
      queue.Remove(n2);
      Assert.AreEqual(queue.ExtractMin(), Pair.Create("c", 3));
    }

    [Test]
    public void Test_73()
    {
      DoSetTest3(1,2,3,4,5);
    }

    [Test]
    public void Test_73_1()
    {
      int[] data = {1, 2, 3, 4, 5};

      Dictionary<int, object> listData = new Dictionary<int, object>();
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

      List<int> keys = new List<int>(listData.Keys);
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
      int[] data = {1, 2, 3, 4, 5};

      Dictionary<int, object> listData = new Dictionary<int, object>();
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

      List<int> keys = new List<int>(listData.Keys);
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
      DoSetTest3(1,2,3,4,5,6,7,8,9);
    }    
    
    [Test]
    public void Test_75()
    {
      DoSetTest3(9,8,7,6);
    }
    
    [Test]
    public void Test_76()
    {
      DoSetTest3(9,8,7,6,5,4,3,2,1);
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

    private static int[] Random(int size)
    {
      List<int> list = new List<int>();
      Random r = new Random((int) DateTime.Now.Ticks);
      while (size-- > 0)
      {
        list.Add(r.Next());
      }
      return list.ToArray();
    }

    private static int[] Random2(int size)
    {
      Hashset<int> list = new Hashset<int>();
      Random r = new Random((int)DateTime.Now.Ticks);
      while (list.Count < size)
      {
        list.Add(r.Next());
      }
      return list.ToArray();      
    }

    private void DoSetTest3(params int[] data)
    {
      for (int p = 1; p < data.Length; p++)
      {
        try
        {
          Dictionary<int, object> listData = new Dictionary<int, object>();
          for (int i = 0; i < data.Length; i++)
          {
            int v = data[i];
            listData.Add(v, queue.AddNode(v, v.ToString()));
          }

          for (int j = 0; j < data.Length; j++)
          {
            if (j % p == 0)
            {
              queue.Remove(listData[data[j]]);
              listData.Remove(data[j]);
            }
          }

          List<int> keys = new List<int>(listData.Keys);
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
        } catch (Exception e)
        {
          throw new Exception("p=" + p + "  " + e.Message, e);
        }
      }
    }

    private void DoSetTest2(params int[] data)
    {
      int? min = null;
      List<int> dta = new List<int>();
      foreach (int i in data)
      {
        if (min == null || min.Value > i)
          min = i;

        queue.AddNode(i, i.ToString());
        dta.Add(i);

        Assert.AreEqual(min, queue.ExtractMin().Second, "Min test failed");
        queue.AddNode(min.Value, min.Value.ToString());
      }

      dta.Sort();

      foreach (int i in dta)
      {
        Assert.AreEqual(i, queue.ExtractMin().Second);
      }
    }

    private void DoSetTest(params int[] data)
    {
      for (int i = 1; i < data.Length; i++)
      {
        List<int> dta = new List<int>();
        string sta = String.Empty;
        for (int j = 0; j < i; j++)
        {
          int v = data[j];
          dta.Add(v);
          sta += " " + v;
          queue.AddNode(v, v.ToString());
        }
        dta.Sort();

        string ddd = string.Format("Step {0}, Data={1}", i, sta.Trim());
        try
        {
          foreach (int v in dta)
          {
            Assert.AreEqual(v, queue.ExtractMin().Second, ddd);
          }
        }
        catch (Exception e)
        {
          throw new Exception(e.Message + ddd, e);
        }
      }
    }

    private class Queue : BinTreePriorityQueueEx<string, int>
    {
      public Queue() : base(IntEqualityComparer.INSTANCE)
      {
      }

      public void Consolidate()
      {
        DoConsolidate();
      }

      public string Min
      {
        get { return myMin == null ? null : myMin.Data; }
      }

      public void Remove(object o)
      {
        base.Remove((Node) o);
      }

      public void AssertConsolidate(params string[] data)
      {
        Consolidate();
        AssertQueue(Dump(), data);
      }

      public void AssertConsolidateGroup(params string[] data)
      {
        Node[] nodes = Group();
        if (nodes == null)
          Assert.AreEqual("[null]", String.Join("", data));
        else
        {
          StringBuilder sb = new StringBuilder();
          foreach (Node node in nodes)
          {
            if (node == null)
            {
              sb.AppendLine("<null>");
            }
            else
            {
              node.Sibling = null;
              node.PrevSibling = null;
              DumpTree("", 0, node, sb);
            }
            sb.AppendLine("|");
          }

          AssertQueue(sb.ToString(), data);
        }
      }

      private static void AssertQueue(string act, params string[] data)
      {
        try
        {
          List<String> actual = new List<String>();
          act = Regex.Replace(act.Trim(), @" d=\d+", "");
          foreach (string trim in act.Split('\n'))
          {
            actual.Add(trim.Trim());
          }

          Assert.AreEqual(string.Join("\n", data).Trim(), string.Join("\n", actual.ToArray()).Trim());
        }
        catch (Exception e)
        {
          Console.Out.WriteLine(act);
          throw new Exception(e.Message, e);
        }
      }


      private static void DumpTree(string so, int offset, Node node, StringBuilder sb)
      {
        sb.AppendFormat("{2}{0, 3}. {1}", offset, node, so);
        sb.AppendFormat(" d={0}", node.Degree);
        sb.AppendLine();

        Node child = node.Child;
        if (child != null)
        {
          DumpTree("  " + so, offset + 1, child, sb);
          for (Node n = child.Sibling; n != child; n = n.Sibling)
            DumpTree("  " + so, offset + 1, n, sb);
        }
      }

      public void Debug()
      {
        Console.Out.WriteLine("Dump() = \n{0}", Dump());
      }

      internal string Dump()
      {
        StringBuilder sb = new StringBuilder();

        if (myMin == null)
          sb.AppendLine("<null>");
        else
        {
          DumpTree("", 0, myMin, sb);

          for (Node node = myMin.Sibling; node != myMin; node = node.Sibling)
          {
            sb.AppendLine("|");
            DumpTree("", 0, node, sb);
          }
        }

        return sb.ToString();
      }
    }
  }
}