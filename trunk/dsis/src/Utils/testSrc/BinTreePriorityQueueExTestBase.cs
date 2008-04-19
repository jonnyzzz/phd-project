using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  public class BinTreePriorityQueueExTestBase : BinTreePriorityQueueExTestBase<string, int, BinTreePriorityQueueExTestBase.Queue> 
  {  
    protected override Queue Create()
    {
      return new Queue();
    }

    protected static int[] Random(int size)
    {
      List<int> list = new List<int>();
      Random r = new Random((int) DateTime.Now.Ticks);
      while (size-- > 0)
      {
        list.Add(r.Next());
      }
      return list.ToArray();
    }

    protected static int[] Random2(int size)
    {
      Hashset<int> list = new Hashset<int>();
      Random r = new Random((int) DateTime.Now.Ticks);
      while (list.Count < size)
      {
        list.Add(r.Next());
      }
      return list.ToArray();
    }

    protected void DoSetTest3(params int[] data)
    {
      for (int p = 1; p < Math.Min(232, data.Length); p++)
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
            if (j%p == 0)
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
        }
        catch (Exception e)
        {
          throw new Exception("p=" + p + "  " + e.Message, e);
        }
      }
    }

    protected void DoSetTest2(params int[] data)
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

    protected void DoSetTest(params int[] data)
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

    public new class Queue : BinTreePriorityQueueExTestBase<string, int, Queue>.Queue
    {
      public Queue() : base(IntEqualityComparer.INSTANCE)
      {
      }
    }     
  }
}