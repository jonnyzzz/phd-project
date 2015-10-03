using DSIS.Graph.Tests.Generic;
using DSIS.IntegerCoordinates.Generated;
using NUnit.Framework;

namespace DSIS.Graph.Generated
{
  [TestFixture]
  public class SimpleGraph2dTest : SimpleGraphTestBase<IntegerCoordinateSystem2d, IntegerCoordinate2d>
  {
    protected override int Dimension
    {
      get { return 2; }
    }

    [Test]
    public void Test_03()
    {
      myGraph.AddNode(mySystem.Create(new long[] { 1, 1, }));
      myGraph.AddNode(mySystem.Create(new long[] { 2, 1, }));

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(0, myGraph.EdgesCount);
    }

    [Test]
    public void Test_04()
    {
      INode<IntegerCoordinate2d> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1, }));
      INode<IntegerCoordinate2d> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1, }));

      myGraph.AddEdgeToNode(node1, node2);

      Assert.AreEqual(2, myGraph.NodesCount);
      Assert.AreEqual(1, myGraph.EdgesCount);
    }

    [Test]
    public void Test_05()
    {
      INode<IntegerCoordinate2d> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1 }));
      INode<IntegerCoordinate2d> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1 }));

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
      INode<IntegerCoordinate2d> node1 = myGraph.AddNode(mySystem.Create(new long[] { 1, 1}));
      INode<IntegerCoordinate2d> node2 = myGraph.AddNode(mySystem.Create(new long[] { 2, 1}));

      myGraph.AddEdgeToNode(node1, node2);
      myGraph.AddEdgeToNode(node2, node1);

      Assert.AreEqual("Graph [Nodes: 2, Edges: 2]\r\n  1 -> { 2,  }}\r\n  2 -> { 1,  }}\r\nFinished!\r\n\r\n",
                      myGraph.Dump());
    }    

    [Test]
    public void Test_07()
    {
      int cnt = 0;
      for (int i = 0; i < 100; i++)
      {
        for (int j = 0; j < 100; j++)
        {
          cnt++;
          for (int k = 0; k < 10; k++ )
            myGraph.AddNode(mySystem.Create(i, j));
        }
      }

      Assert.AreEqual(cnt, myGraph.NodesCount);

      foreach (INode<IntegerCoordinate2d> node in myGraph.Nodes)
      {
        cnt--;
      }

      Assert.AreEqual(0, cnt);
    }
  }
}