using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Abstract;
using DSIS.Graph.Abstract.NodeSets;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class GraphNodeHashListTest
  {
    [Test]
    public void Test_1000_10()
    {
      doTest(10, 1000);
    }
    
    [Test]
    public void Test_1000_1()
    {
      doTest(1, 1000);
    }

    [Test]
    public void Test_1000_1000()
    {
      doTest(1000, 1000);
    }

    [Test]
    public void Test_1_10000()
    {
      doTest(1000, 1);
    }
    
    private void DoPerformanceTest(int size)
    {
      var list = new GraphList(size/6);
      for(int i = 0; i <size; i++)
      {
        var node = new FakeNode(i);
        bool _;
        list.AddIfNotReplace(node.Coordinate, new FakeNodeFactory(), out _);
      }

      var s = MeasureTime("IEnumerable: ", ()=>
                                             {
                                              var z = new List<FakeNode>();
                                               long i = 0;
                                               foreach (var n in list.Values)
                                               {
                                                 i += n.Coordinate.GetCoordinate(0);
                                                 z.Add(n);
                                               }
                                               return z;
                                             });
      Console.Out.WriteLine("s = {0}", s.Count);
    }

    [Test]
    public void DoPerformanceTest_100k()
    {
      DoPerformanceTest(100000);
    }

    private static T MeasureTime<T>(string name, Func<T> a)
    {
      DateTime time = DateTime.Now;
      try
      {
        return a();
      } finally
      {
        var s = DateTime.Now - time;
        Console.Out.WriteLine("Action {1} took {0}ms", s.TotalMilliseconds, name);
      }
    }

    private static void doTest(int hash, int N)
    {
      var list = new GraphList(hash);      
      var data = new List<long>();
      for(int i = 0; i < N; i++)
      {
        data.Add(i);
        var node = new FakeNode(i);
        bool wasAdded;
        Assert.That(list.AddIfNotReplace(node.Coordinate, new FakeNodeFactory(), out wasAdded), Is.Not.Null);
        Assert.That(wasAdded, Is.True);
      }

      var fakeNodes = new List<FakeNode>(list.Values);
      var nodes = fakeNodes.ConvertAll(node => node.Coordinate.GetCoordinate(0));

      nodes.Sort();
      data.Sort();

      Assert.AreEqual(data.Count, nodes.Count);

      for(int i=0; i<data.Count; i++)
      {
        Assert.AreEqual(data[i], nodes[i]);
      }
    }

    private class FakeNodeFactory : IGraphNodeFactory<FakeNode, IntegerCoordinate>
    {
      public FakeNode CreateNode(IntegerCoordinate coordinate)
      {
        return new FakeNode(coordinate.GetCoordinate(0));
      }
    }


    private class GraphList : GraphNodeHashList<FakeNode, IntegerCoordinate>
    {
      public GraphList(int capacity) : base(capacity)
      {
      }
    }

    private class FakeNode : Node<FakeNode, IntegerCoordinate>
    {
      public FakeNode(long coordinate) : base(new IntegerCoordinate(coordinate))
      {
      }
    }
  }
}