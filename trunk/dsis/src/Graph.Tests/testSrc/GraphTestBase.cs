using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class TarjanGraphTest : GraphTestBase<TarjanGraph<IntegerCoordinate>>
  {
    protected override TarjanGraph<IntegerCoordinate> CreateGraph(IntegerCoordinateSystem ics)
    {
      return new TarjanGraph<IntegerCoordinate>(ics);
    }
  }

  public abstract class GraphTestBase<T> where T : IGraph<IntegerCoordinate>
  {
    private T myGraph;

    [SetUp]
    public virtual void SetUp()
    {
      var ics = new IntegerCoordinateSystem(new MockSystemSpace(1,0,1000,1000000));
      myGraph = CreateGraph(ics);
    }

    protected abstract T CreateGraph(IntegerCoordinateSystem ics);
  
  
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
      INode<IntegerCoordinate> n_i = myGraph.Nodes.Find(null, x => x.Coordinate.GetCoordinate(0) == i);
      INode<IntegerCoordinate> n_j = myGraph.GetEdges(n_i).Find(null, x => x.Coordinate.GetCoordinate(0) == j);

      Assert.That(n_i, Is.Not.Null);
      Assert.That(n_j, Is.Not.Null);     
    }

    protected void nan(int i)
    {
      INode<IntegerCoordinate> n_i = myGraph.Nodes.Find(null, x => x.Coordinate.GetCoordinate(0) == i);
      Assert.That(n_i, Is.Null);
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
    
  }
}