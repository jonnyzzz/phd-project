using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.Utils.testSrc
{
  [TestFixture]
  public class BinTreePriorityQueueExTestAllCases : BinTreePriorityQueueExTestBase
  {
    [Test]
    public void Test_001_1()
    {
      queue.AddNode(1, "1");
      Assert.AreEqual(queue.ExtractMin().Second, 1);
      Assert.AreEqual(queue.Count, 0);
    }

    [Test]
    public void Test_001_2()
    {
      object n1 = queue.AddNode(1, "1");
      queue.Remove(n1);
      Assert.AreEqual(queue.Count, 0);
    }

    [Test]
    public void Test_001_3()
    {
      object n1 = queue.AddNode(1, "1");
      queue.Remove(n1);
      Assert.AreEqual(queue.Count, 0);
      queue.AddNode(1, "1");
      Assert.AreEqual(queue.ExtractMin().Second, 1);
      Assert.AreEqual(queue.Count, 0);
    }

    [Test]
    public void MegaTest_1()
    {
      MegaTest(1);
    }

    [Test]
    public void MegaTest_2()
    {
      MegaTest(2);
    }

    [Test]
    public void MegaTest_3()
    {
      MegaTest(3);
    }


    public void Test_Permute_1()
    {
      List<int[]> list = new List<int[]>(Permute(new int[] {1}));
      Assert.IsTrue(list.Count == 1);
      Assert.AreEqual(list[0], new int[] {1});
    }

    public void Test_Permute_2()
    {
      List<int[]> list = new List<int[]>(Permute(new int[] {1, 2}));
      Assert.IsTrue(list.Count == 2);

      Assert.AreEqual(list[0], new int[] {2, 1});
      Assert.AreEqual(list[1], new int[] {1, 2});
    }

    public void Test_Permute_3()
    {
      List<int[]> list = new List<int[]>(Permute(new int[] {1, 2, 3}));
      Assert.IsTrue(list.Count == 6);

      Assert.AreEqual(list[0], new int[] {3, 2, 1,});
      Assert.AreEqual(list[1], new int[] {2, 3, 1,});
      Assert.AreEqual(list[2], new int[] {3, 1, 2,});
      Assert.AreEqual(list[3], new int[] {1, 3, 2,});
      Assert.AreEqual(list[4], new int[] {2, 1, 3,});
      Assert.AreEqual(list[5], new int[] {1, 2, 3,});
    }

    public void Test_NonZero_1()
    {
      int[] bits = new List<int>(NonZeroBits(4)).ToArray();
      Assert.AreEqual(bits, new int[] {2});
    }

    public void Test_NonZero_2()
    {
      int[] bits = new List<int>(NonZeroBits(3)).ToArray();
      Assert.AreEqual(bits, new int[] {0, 1});
    }

    public void Test_NonZerp_3()
    {
      List<int[]> list = new List<int[]>();
      foreach (IEnumerable<int> enumerable in NVector(2))
      {
        list.Add(new List<int>(enumerable).ToArray());
      }

      Assert.AreEqual(list.Count, 4);
      Assert.AreEqual(list[0], new int[] {});
      Assert.AreEqual(list[1], new int[] {0});
      Assert.AreEqual(list[2], new int[] {1});
      Assert.AreEqual(list[3], new int[] {0, 1});
    }


    private void MegaTest(int v)
    {
      foreach (int[] ints in Permute(Array(v)))
      {
        Dump(ints);

        foreach (IEnumerable<int> enumerable in NVector(v))
        {
          Dictionary<int, object> data = new Dictionary<int, object>();

          foreach (int i in ints)
          {
            data.Add(i, queue.AddNode(i, i.ToString()));
          }
          foreach (int i in enumerable)
          {
            queue.Remove(data[ints[i]]);
            data.Remove(ints[i]);
          }

          List<int> l = new List<int>(data.Keys);
          l.Sort();
          foreach (int i in l)
          {
            Assert.AreEqual(i, queue.ExtractMin().Second);
          }
        }
      }
    }


    private static void Dump(IEnumerable<int[]> l)
    {
      foreach (int[] ints in l)
      {
        Dump(ints);
      }
    }

    private static void Dump<T>(IEnumerable<T> ints)
    {
      foreach (T i in ints)
      {
        Console.Out.Write(i + ", ");
      }
      Console.Out.WriteLine();
    }

    private class Assert : NUnit.Framework.Assert
    {
      public static void AreEqual<T>(T[] a, T[] b)
      {
        try
        {
          AreEqual(a.Length, b.Length);
          for (int i = 0; i < a.Length; i++)
          {
            AreEqual(a[i], b[i]);
          }
        }
        catch (Exception e)
        {
          Dump(a);
          throw new Exception(e.Message, e);
        }
      }
    }


    private static IEnumerable<IEnumerable<int>> NVector(int len)
    {
      int p = 1;
      for (int i = 0; i < len; i++)
      {
        p *= 2;
      }
      for (int i = 0; i < p; i++)
      {
        yield return NonZeroBits(i);
      }
    }

    private static int[] Array(int n)
    {
      int[] a = new int[n];
      for(int i=0; i<n; i++)
      {
        a[i] = i;
      }
      return a;
    }

    private static IEnumerable<int> NonZeroBits(int b)
    {
      int bit = 0;
      while (b != 0)
      {
        if (b%2 == 1)
          yield return bit;

        b /= 2;
        bit++;
      }
    }

    private static IEnumerable<int[]> Permute(int[] data)
    {
      int[] ids = new int[data.Length + 1];
      while (ids[data.Length] == 0)
      {
        Hashset<int> check = new Hashset<int>();
        bool fail = false;
        for (int i = 0; i < data.Length; i++)
        {
          if (check.Contains(ids[i]))
          {
            fail = true;
            break;
          }
          check.Add(ids[i]);
        }
        if (!fail)
        {
          int[] set = new int[data.Length];
          for (int i = 0; i < data.Length; i++)
          {
            set[i] = data[ids[i]];
          }
          yield return set;
        }

        ids[0]++;
        for (int i = 0; i < data.Length; i++)
        {
          if (ids[i] >= data.Length)
          {
            ids[i] -= data.Length;
            ids[i + 1]++;
          }
        }
      }
    }
  }
}