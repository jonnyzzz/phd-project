using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Graph.Tests
{
  public abstract class GraphTestBase<T, TNode> 
    where T : AbstractGraph<T, IntegerCoordinate, TNode>, IGraphExtension<TNode, IntegerCoordinate>
    where TNode : Node<TNode, IntegerCoordinate>
  {
    protected T myGraph;

    [SetUp]
    public virtual void SetUp()
    {
      var ics = new IntegerCoordinateSystem(new MockSystemSpace(1,0,10000,1000000));
      myGraph = CreateGraph(ics);
    }

    protected abstract T CreateGraph(IntegerCoordinateSystem ics);
  
    protected TNode n(int i)
    {
      return myGraph.AddNode(new IntegerCoordinate(i));
    }
  
    protected void n(int i, int j)
    {
      var n_i = myGraph.AddNode(new IntegerCoordinate(i));
      var n_j = myGraph.AddNode(new IntegerCoordinate(j));

      Assert.That(n_i, Is.Not.Null, "Node {0}", i);
      Assert.That(n_j, Is.Not.Null, "Node {0}", j);

      myGraph.AddEdgeToNode(n_i, n_j);
    }


    protected void an(int i, int j)
    {
      an(myGraph, i, j);
    }

    protected void an(T graph, int i, int j)
    {
      INode<IntegerCoordinate> n_i = graph.Nodes.Find(null, x => x.Coordinate.GetCoordinate(0) == i);
      INode<IntegerCoordinate> n_j = graph.GetEdges(n_i).Find(null, x => x.Coordinate.GetCoordinate(0) == j);

      Assert.That(n_i, Is.Not.Null, "Node from " + i);
      Assert.That(n_j, Is.Not.Null, "Node to " + j);     
    }

    protected TNode nan(int i)
    {
      var n_i = myGraph.NodesInternal.Find(null, x => x.Coordinate.GetCoordinate(0) == i);
      Assert.That(n_i, Is.Null);
      return n_i;
    }

    protected TNode an(int i)
    {
      return an(myGraph, i);
    }

    protected TNode an(T graph, int i)
    {
      var n_i = graph.NodesInternal.Find(null, x => x.Coordinate.GetCoordinate(0) == i);
      Assert.That(n_i, Is.Not.Null);
      return n_i;
    }

    [Test]
    public void Test_CanStoreArc()
    {
      for(int i =0; i<100; i++)
      {
        n(i, i + 200);
      }

      for(int i = 0; i<100; i++)
      {
        an(i, i + 200);
      }
    }

    [Test]
    public void Test_NoEdges()
    {
      for(int i=0; i<1000; i++)
      {
        nan(i);
      }
    }

    [Test]
    public void Test_MoreArcs()
    {
      for(int i=1; i<1000; i++)
      {
        n(0, i);
      }
      
      for(int i=1; i<1000; i++)
      {
        an(0, i);
      }
    }
    
    [Test]
    public void Test_MoreArcs2()
    {
      for (int j = 2; j <= 50; j++ )
      {
        for (int i = 1; i < j; i++)
        {
          n(0, i);
        }

        for (int i = 1; i < j; i++)
        {
          an(0, i);
        }
      }
    }

    [Test]
    public void Test_FullGraph()
    {
      for(int i=0; i<100; i++)
      {
        for(int j=0; j<100; j++)
        {
          n(i, j);
        }
      }
      for(int i=0; i<100; i++)
      {
        an(i);
        for(int j=0; j<100; j++)
        {
          an(i, j);
        }
      }
    }

    [Test]
    public void Test_DetectLoop()
    {
      n(0, 0);
      Assert.IsTrue(myGraph.IsSelfLoop(new IntegerCoordinate(0)));      
    }
    
    [Test]
    public void Test_DetectLoop2()
    {
      n(0, 1);
      Assert.IsFalse(myGraph.IsSelfLoop(new IntegerCoordinate(0)));      
      Assert.IsFalse(myGraph.IsSelfLoop(new IntegerCoordinate(1)));      
    }
    
  }
}