using System.Collections.Generic;
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