/*
 * Created by: Eugene.Petrenko
 * Created: 3 декабря 2006 г.
 */

using DSIS.Graph.Tests.Generic;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Tests.Impl
{
  [TestFixture]
  public class SimpleGraphTest : SimpleGraphTestBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
    protected override int Dimension
    {
      get { return 5; }
    }

    [Test]
    public void Test_03()
    {
      myGraph.AddNode(mySystem.Create(new long[] {1, 1, 1, 1, 1}));
      myGraph.AddNode(mySystem.Create(new long[] {2, 1, 1, 1, 1}));

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(0, myGraph.EdgesCount);
    }

    [Test]
    public void Test_04()
    {
      INode<IntegerCoordinate> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1, 1, 1, 1 }));

      myGraph.AddEdgeToNode(node1, node2);

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(1, myGraph.EdgesCount);
    }

    [Test]
    public void Test_05()
    {
      INode<IntegerCoordinate> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1, 1, 1, 1 }));

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
      INode<IntegerCoordinate> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1, 1, 1, 1 }));
      INode<IntegerCoordinate> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1, 1, 1, 1 }));

      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node2, node1);

      Assert.AreEqual("Graph [Nodes: 2, Edges: 2]\r\n  1 -> { 2,  }}\r\n  2 -> { 1,  }}\r\nFinished!\r\n\r\n",
                      myGraph.Dump());
    }
  }
}