using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class BinTreePriorityQueueTest
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
      queue.Enqueue(Pair.Create("a", 1));
      
      
      AssertMin(1, "a");      
      AssertQueue(@"0. 1(a)");      

      queue.Consolidate2();

      AssertMin(1, "a");
      AssertQueue(@"0. 1(a)");

      AssertMin(1);
    }
    
    [Test]
    public void Test_02()
    {
      queue.Enqueue(Pair.Create("a", 1));
      queue.Enqueue(Pair.Create("b", 0));

      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "0. 1(a)");

      queue.Consolidate2();

      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "1. 1(a)");

      AssertMin(0, 1);
    }
    
    [Test]
    public void Test_03()
    {
      queue.Enqueue(Pair.Create("a", 1), Pair.Create("aa", 1), Pair.Create("b", 0));

      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "0. 1(a)", "0. 1(aa)");

      queue.Consolidate2();
      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "1. 1(a)", "0. 1(aa)");

      AssertMin(0, 1, 1);
    }
    
    [Test]
    public void Test_04()
    {      
      Pair<string, int> data1 = Pair.Create("a", 1);
      Pair<string, int> data2 = Pair.Create("aa", 1);
      Pair<string, int> data3 = Pair.Create("b", 0);
      Pair<string, int> data4 = Pair.Create("aaa", 1);
      queue.Enqueue(data1, data2, data3, data4);

      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "0. 1(aaa)", "0. 1(a)", "0. 1(aa)");

      queue.Consolidate2();
      AssertMin(0, "b");
      AssertQueue("0. 0(b)", "1. 1(aa)", "2. 1(a)", "1. 1(aaa)");

      AssertMin(0, 1, 1, 1);
    }
    
    [Test]
    public void Test_05()
    {      
      Pair<string, int> data1 = Pair.Create("a", 1);
      Pair<string, int> data2 = Pair.Create("aa", 1);
      Pair<string, int> data3 = Pair.Create("b", 0);
      Pair<string, int> data4 = Pair.Create("aaa", 1);
      Pair<string, int> data5 = Pair.Create("m", -1);
      queue.Enqueue(data1, data2, data3, data4, data5);

      AssertMin(-1, "m");
      AssertQueue("0. -1(m)", "0. 0(b)", "0. 1(aaa)", "0. 1(a)", "0. 1(aa)");
      
      queue.Consolidate2();
      
      AssertMin(-1, "m");
      AssertQueue("0. -1(m)", "1. 1(a)", "2. 1(aaa)", "1. 0(b)", "0. 1(aa)");

      AssertMin(-1, 0, 1, 1, 1);
    }

    [Test]
    public void Test_06()
    {
      DoSetTest(1,2,3,4,56,7,8,89,6,5345,43);
    }
    
    [Test]
    public void Test_07()
    {
      DoSetTest(9,8,7,6,5,4,3,2,1);
    }
    
    [Test]
    public void Test_08()
    {
      DoSetTest(9,8,7,6,5,4,3,2,1,0,1,2,3,4,5,6,7,8,9);
    }
    
    [Test]
    public void Test_09()
    {
      DoSetTest(9,8,7,99,6,5,499,3,2,1666,0,1,2,3,4,5,6,777,7,8,9);
    }
    
    [Test]
    public void Test_10()
    {
      DoSetTest(9,8,7,99,6,5,499,3,2,1666,0,1,2,3,4,5,6,777,7,8,9);
    }
    
    [Test]
    public void Test_11()
    {
      DoSetTest(Random(55));
    }
    
    [Test]
    public void Test_12()
    {
      DoSetTest(Random(155));
    }

    [Test]
    public void Test_13()
    {
      DoSetTest(Random(2155));
    }

    [Test]
    public void Test_14()
    {
      DoSetTest(Random(2355));
    }

    [Test]
    public void Test_16()
    {
      DoSetTest(Random(32355));
    }

    [Test]
    public void Test_17()
    {
      DoSetTest(Random(62355));
    }

    [Test]
    public void Test_18()
    {
      DoSetTest(Random(128355));
    }
    
    [Test]
    public void Test_19()
    {
      DoSetTest2(Random(355));
    }
    
    [Test]
    public void Test_20()
    {
      DoSetTest2(Random(555));
    }

    private static int[] Random(int size)
    {
      List<int> list = new List<int>();
      Random r = new Random((int)DateTime.Now.Ticks);
      while(size-- > 0)
      {
        list.Add(r.Next());
      }
      return list.ToArray();
    }

    private void DoSetTest(params int[] data)
    {
      int? min = null;
      List<int> dta = new List<int>();
      foreach (int i in data)
      {
        if (min == null || min.Value >  i)
          min = i;

        queue.Enqueue(new Pair<string, int>(i.ToString(), i));
        dta.Add(i);

        Assert.AreEqual(min, queue.Dequeue().Second, "Min test failed");
        queue.Enqueue(new Pair<string, int>(min.ToString(), min.Value));
      }

      dta.Sort();

      foreach (int i in dta)
      {        
        Assert.AreEqual(i, queue.Dequeue().Second);
      }
    }
    
    private void DoSetTest2(params int[] data)
    {
      for(int i=1; i < data.Length; i++)
      {
        List<int> dta = new List<int>();
        for (int j =0; j<i; j++)
        {          
          int v = data[j];
          dta.Add(v);
          queue.Enqueue(new Pair<string, int>(v.ToString(), v));          
        }
        dta.Sort();

        foreach (int v in dta)
        {
          Assert.AreEqual(v, queue.Dequeue().Second);
        }        
      }      
    }
    
    private void AssertMin(int v, string d)
    {
      queue.AssertMin(new Pair<string, int>(d, v));
    }

    private void AssertMin(params int[] iz)
    {
      foreach (int i in iz)
      {
        Assert.AreEqual(i, queue.Dequeue().Second);
      }
    }

    private void AssertQueue(params string[] data)
    {
      try
      {
        List<String> actual = new List<String>();
        string act = queue.Dump().Trim();
        act = Regex.Replace(act, @" d=\d+", "");
        foreach (string trim in act.Split('\n'))
        {
          actual.Add(trim.Trim());
        }

        Assert.AreEqual(string.Join("\n", data).Trim(), string.Join("\n", actual.ToArray()).Trim());
      }
      catch(Exception e)
      {
        Console.Out.WriteLine(queue.Dump());
        throw new Exception(e.Message, e);
      }
    }

    private class Queue : BinTreePriorityQueue<string, int>
    {      
      public void Enqueue(params Pair<string, int>[] data)
      {
        foreach (Pair<string, int> pair in data)
        {
          base.Enqueue(pair);
        }
      }

      public void Consolidate2()
      {
        Consolidate();
      }

      public void AssertMin()
      {
        Assert.IsNotNull(myMin);
      }

      public void AssertMin(Pair<string, int> expected)
      {
        Assert.IsNotNull(myMin);
        Assert.AreEqual(expected, myMin.Pair);
      }

      private static void DumpTree(string so, int offset, Node node, StringBuilder sb)
      {
        sb.AppendFormat("{2}{0, 3}. {1}", offset, node, so);
        sb.AppendFormat("d={0}", node.Degree);
        sb.AppendLine();
        for (Node n = node.Child; n != null; n = n.Sibling)
          DumpTree("  " + so, offset + 1, n, sb);
      }

      internal string Dump()
      {
        StringBuilder sb = new StringBuilder();
        for (Node node = myMin; node != null; node = node.Sibling)
        {
          DumpTree("", 0, node, sb);
        }

        return sb.ToString();
      }
    }
  }
}
