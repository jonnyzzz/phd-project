using System.Linq;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture, Ignore]
  public class AllEngesOnALoopGraphSearchTest : GraphSearchTest
  {
    protected override ILoopIterator Create<T>(IGraph<T> graph, ILoopIteratorCallback<T> mcb,
                                                  IGraphStrongComponents<T> components)
    {
      return new AllEngesOnALoopGraphSearch<T>(mcb, components, components.Components.First());
    }

    [Test]
    public void Test_03()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 var system = (IntegerCoordinateSystem) graph.CoordinateSystem;
                 INode<IntegerCoordinate> n1 = graph.AddNode(system.Create(1));
                 INode<IntegerCoordinate> n2 = graph.AddNode(system.Create(2));
                 INode<IntegerCoordinate> n3 = graph.AddNode(system.Create(3));
                 INode<IntegerCoordinate> n4 = graph.AddNode(system.Create(4));

                 graph.AddEdgeToNode(n1, n2);
                 graph.AddEdgeToNode(n2, n3);
                 graph.AddEdgeToNode(n3, n4);
                 graph.AddEdgeToNode(n4, n1);
               },
             "2, 3, 4, 1,");
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
               }, "3, 2,");
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
               },
             "3, 1,",
             "2, 3, 1,"
        );
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
               },
             "2, 3, 5, 1, ",
             "6, 2, 3, 8, 7,"
//             "2, 3, 5, 1, ",
//             "3, 5, 1, 2,",
//             "8, 7, 6, 2, 3,",
//             "5, 1, 2, 3,",
//             "1, 2, 3, 5,",
//             "2, 3, 8, 7, 6,",
//             "6, 2, 3, 8, 7,",
//             "7, 6, 2, 3, 8,"
        );
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
               },
             "2, 1, ",
             "8, 7, 6, 2, 3, ",
             "5, 1, 2, 3,"
//             "2, 1,",
//             "3, 1, 2,",
//             "1, 2,",
//             "8, 7, 6, 2, 3,",
//             "1, 2, 3,",
//             "5, 1, 2, 3,",
//             "1, 2, 3, 5,",
//             "2, 3, 8, 7, 6,",
//             "6, 2, 3, 8, 7,",
//             "7, 6, 2, 3, 8,"
        );
    }
  }
}