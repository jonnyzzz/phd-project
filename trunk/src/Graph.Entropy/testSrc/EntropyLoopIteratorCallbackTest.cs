using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class EntropyLoopIteratorCallbackTest : GraphBaseTest
  {
    [Test]
    public void Test_01()
    {
      double p = 0.25;
      DoTest2(ll(l(1,2,3,4)), 0, d(1,2,p), d(2,3,p), d(3,4,p), d(4,1,p));
    }

    [Test]
    public void Test_02()
    {
      double p = 1.0/7.0;
      DoTest2(ll(l(1,2,3,4,5,6,7)), 0, d(1,2,p), d(2,3,p), d(3,4,p), d(4,5,p), d(5,6,p), d(6,7,p), d(7,1,p));
    }

    [Test]
    public void Test_03()
    {
      double p = 1.0;
      DoTest2(ll(l(1)), 0, d(1,1,p));
    }

    [Test]
    public void Test_04()
    {
      double p = 0.2;
      double q = 0.25;
      DoTest2(ll(l(1,2,3,5), l(2,3,8,7,6)), 0.22299, d(1,2,q), d(2,3, p+q), d(3,5,q), d(5,1,q), d(3,8,p), d(8,7,p), d(7,6,p), d(6,2,p));
    }


    private static List<int> l(params int[] @is)
    {
      return new List<int>(@is);
    }

    private static List<List<int>> ll(params List<int>[] ls)
    {
      return new List<List<int>>(ls);
    }

    private static string d(int i, int j, double d)
    {
      return i + "->" + j + "=" + d.ToString("F6", CultureInfo.InvariantCulture);
    }

    protected static void DoTest2(List<List<int>> loops, double expectedEntropy, params string[] expected)
    {
      double ent = DoTest(loops, expected).ComputeAntropy(NullProgressInfo.INSTANCE);
      try
      {
        Assert.AreEqual(expectedEntropy, ent, 1e-4);                
      } catch
      {
        Console.Error.Write(ent);
      }
    }

    protected static EntropyGraphWeightCallback<IntegerCoordinate> DoTest(List<List<int>> loops, params string[] expected)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(delegate { });

      foreach (List<int> loop in loops)
      {
        foreach (int i in loop)
        {
          graph.AddNode(new IntegerCoordinate(i));
        }
      }

      EntropyGraphWeightCallback<IntegerCoordinate> cb =
        new EntropyGraphWeightCallback<IntegerCoordinate>();

      foreach (List<int> loop in loops)
      {
        List<INode<IntegerCoordinate>> nodes =
          loop.ConvertAll<INode<IntegerCoordinate>>(
            delegate(int input) { return graph.AddNode(new IntegerCoordinate(input)); });

        cb.OnLoopFound(nodes);
      }

      Assert.AreEqual(loops.Count, loops.Count);

      int index = 0;
      Exception e = null;
      StringBuilder sb = new StringBuilder();
      foreach (KeyValuePair<NodePair<IntegerCoordinate>, double> pair in cb.M)
      {
        string s = ToString(pair.Key) + "=" + pair.Value.ToString("F6", CultureInfo.InvariantCulture);
        sb.AppendLine(s);
        if (e == null)
        {
          try
          {
            Assert.AreEqual(expected[index++], s);
          } catch(Exception ee)
          {
            e = new Exception("Compare failed at line " + index, ee);
          }
        }
      }
      if (e != null)
      {
        Console.Out.WriteLine(sb);
        throw e;
      }

      return cb;
    }
  }
}