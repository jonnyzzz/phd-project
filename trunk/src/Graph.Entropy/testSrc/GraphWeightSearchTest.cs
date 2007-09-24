/*
 * Created by: 
 * Created: 27 марта 2007 г.
 */

using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class GraphWeightSearchTest : GraphSearchTest
  {
    protected override ILoopIterator<T> Create<T>(IGraph<T> graph, ILoopIteratorCallback<T> mcb, IGraphStrongComponents<T> components) 
    {
      return new GraphWeightSearch<T>(mcb, components, GetFirst(components.Components));
    }

    [Test][ExpectedException]
    public void Test_02()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 IntegerCoordinateSystem system = (IntegerCoordinateSystem) graph.CoordinateSystem;
                 INode<IntegerCoordinate> n1 = graph.AddNode(system.Create(1));
                 INode<IntegerCoordinate> n2 = graph.AddNode(system.Create(2));
                 INode<IntegerCoordinate> n3 = graph.AddNode(system.Create(3));
                 INode<IntegerCoordinate> n4 = graph.AddNode(system.Create(4));

                 graph.AddEdgeToNode(n1, n2);
                 graph.AddEdgeToNode(n2, n3);
                 graph.AddEdgeToNode(n3, n4);
               }, @"");
    }

    [Test]
    public void Test_03()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 IntegerCoordinateSystem system = (IntegerCoordinateSystem)graph.CoordinateSystem;
                 INode<IntegerCoordinate> n1 = graph.AddNode(system.Create(1));
                 INode<IntegerCoordinate> n2 = graph.AddNode(system.Create(2));
                 INode<IntegerCoordinate> n3 = graph.AddNode(system.Create(3));
                 INode<IntegerCoordinate> n4 = graph.AddNode(system.Create(4));

                 graph.AddEdgeToNode(n1, n2);
                 graph.AddEdgeToNode(n2, n3);
                 graph.AddEdgeToNode(n3, n4);
                 graph.AddEdgeToNode(n4, n1);
               }, "1, 2, 3, 4,");
    }

    [Test]
    public void Test_04()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 1, 3);
                 AddEdge(graph, 3, 2);
                 AddEdge(graph, 2, 3);
               }, "2, 3,");
    }

    [Test]
    public void Test_05()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2); //                    1 \
                 AddEdge(graph, 1, 3); //                  2 <-> 3
                 AddEdge(graph, 3, 2); //                 
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 1);
               }, "1, 3, ");
    }
    
    [Test]
    public void Test_05_5()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2); //                    1 \
                 AddEdge(graph, 1, 3); //                  2 -> 3 -> 4 -> 2
                 AddEdge(graph, 1, 4); // 
                 
                 AddEdge(graph, 2, 3);                 
                 AddEdge(graph, 3, 4);
                 AddEdge(graph, 5, 1);
               }, "2, 3, 4, ");
    }
    

    [Test]
    public void Test_05_6()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2); //                    1 \
                 AddEdge(graph, 1, 3); //                  2 <-> 3 -> 4 -> 2
                 AddEdge(graph, 1, 4); // 
                 
                 AddEdge(graph, 2, 3);                 
                 AddEdge(graph, 3, 2);                 
                 AddEdge(graph, 3, 4);
                 AddEdge(graph, 5, 1);
               }, "2, 3, ", "2, 3, 4, ");
    }
    
    [Test]
    public void Test_06()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2); 
                 AddEdge(graph, 2, 3); //                 
                 AddEdge(graph, 3, 5);
                 AddEdge(graph, 3, 8);

                 AddEdge(graph, 5, 1);

                 AddEdge(graph, 8, 7);
                 AddEdge(graph, 7, 6);
                 AddEdge(graph, 6, 2);
               }, "1, 2, 3, 5,", "2, 3, 8, 7, 6," );
    }
    
    [Test]
    public void Test_07()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2); 
                 AddEdge(graph, 2, 1); 
                 AddEdge(graph, 2, 3);                 
                 AddEdge(graph, 3, 1);                 
                 AddEdge(graph, 3, 5);
                 AddEdge(graph, 3, 8);
                 AddEdge(graph, 5, 1);
                 AddEdge(graph, 8, 7);
                 AddEdge(graph, 7, 6);
                 AddEdge(graph, 6, 2);
               }, "1, 2,", "1, 2, 3,", "1, 2, 3, 5,", "2, 3, 8, 7, 6," );
    }


    protected static BuildGraph BuildFullGraph(int pow)
    {      
      return delegate(IGraph<IntegerCoordinate> graph)
               {
                 for (int i = 1; i <= pow; i++)
                   for (int j = 1; j <= pow; j++)
                   {
                     AddEdge(graph, i, j);
                   }
               };
    }


    [Test]
    public void Test_08_full3()
    {
      DoTest(BuildFullGraph(3), "1, ", "3, ", "1, 3, ", "1, 2,", "2," );
    }
    
    [Test]
    public void Test_09_full4()
    {
      DoTest(BuildFullGraph(4), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 2,", "2," );
    }
    
    [Test]
    public void Test_09_full5()
    {
      DoTest(BuildFullGraph(5), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2," );
    }
    
    [Test]
    public void Test_09_full6()
    {
      DoTest(BuildFullGraph(6), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2,", "1, 6,", "6, " );
    }

    [Test]
    public void Test_09_full7()
    {
      DoTest(BuildFullGraph(7), "1, ", "3, ", "1, 3, ", "7, ", "1, 7, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2,", "1, 6,", "6, " );
    }
  }
}