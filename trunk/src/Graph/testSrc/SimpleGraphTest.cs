/*
 * Created by: 
 * Created: 3 декабря 2006 г.
 */

using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class SimpleGraphTest
  {
    private SimpleGraph<IntegerCoordinate> myGraph;

    [SetUp]
    public void SetUp()
    {
      myGraph = new SimpleGraph<IntegerCoordinate>(
        new IntegerCoordinateSystem(new MockSystemSpace(5, 0, 1, 100)));      
    }

    [TearDown]
    public void TearDown()
    {
      myGraph = null;
    }

    [Test]
    public void Test_01()
    {
      Assert.AreEqual("Graph [Nodes: 0, Edges: 0]\r\nFinished!\r\n\r\n", myGraph.Dump());
    }
    
    [Test]
    public void Test_02()
    {
      Assert.AreEqual("Graph [Nodes: 0, Edges: 0]", myGraph.ToString());
    }
    
    [Test]
    public void Test_03()
    {
      myGraph.AddNode(new IntegerCoordinate(new long[] {1, 1, 1, 1, 1}));
      myGraph.AddNode(new IntegerCoordinate(new long[] {2, 1, 1, 1, 1}));

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(0, myGraph.EdgesCount);
    }

    [Test]
    public void Test_04()
    {
      INode<IntegerCoordinate> node1 = myGraph.AddNode(new IntegerCoordinate(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(new IntegerCoordinate(new long[] { 2, 1, 1, 1, 1 }));

      myGraph.AddEdgeToNode(node1, node2);

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(1, myGraph.EdgesCount);
    }

    [Test]
    public void Test_05()
    {
      INode<IntegerCoordinate> node1 = myGraph.AddNode(new IntegerCoordinate(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(new IntegerCoordinate(new long[] { 2, 1, 1, 1, 1 }));

      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node1, node2);

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(1, myGraph.EdgesCount);
    }

    [Test]
    public void Test_06()
    {
      INode<IntegerCoordinate> node1 = myGraph.AddNode(new IntegerCoordinate(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(new IntegerCoordinate(new long[] { 2, 1, 1, 1, 1 }));

      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node2, node1);

      Assert.AreEqual("Graph [Nodes: 2, Edges: 2]\r\n  1 -> { 2,  }}\r\n  2 -> { 1,  }}\r\nFinished!\r\n\r\n", myGraph.Dump());      
    }
  }
}