using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Graph.Entropy.Tests;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class GraphWeightSearchTest : GraphSearchTest
  {
    protected override ILoopIterator Create<T>(IGraph<T> graph, ILoopIteratorCallback<T> mcb,
                                                  IGraphStrongComponents<T> components)
    {
      IStrongComponentInfo first = CollectionUtil.GetFirst(components.Components);
      return new LoopIteratorFirst<T>(mcb, components, first, new GraphWeightSearch<T>(components, first));
    }

    [Test]
    public void Test_03()
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
               }, "2, 3, ");
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
               }, "1, 2, 3, 5,", "2, 3, 8, 7, 6,");
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
               }, "1, 2,", "1, 2, 3,", "1, 2, 3, 5,", "2, 3, 8, 7, 6,");
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
      DoTest(BuildFullGraph(3), "1, ", "3, ", "1, 3, ", "1, 2,", "2,");
    }

    [Test]
    public void Test_09_full4()
    {
      DoTest(BuildFullGraph(4), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 2,", "2,");
    }

    [Test]
    public void Test_09_full5()
    {
      DoTest(BuildFullGraph(5), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2,");
    }

    [Test]
    public void Test_09_full6()
    {
      DoTest(BuildFullGraph(6), "1, ", "3, ", "1, 3, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2,", "1, 6,", "6, ");
    }

    [Test]
    public void Test_09_full7()
    {
      DoTest(BuildFullGraph(7), "1, ", "3, ", "1, 3, ", "7, ", "1, 7, ", "4, ", "1, 4, ", "1, 5, ", "5,", "1, 2,", "2,",
             "1, 6,", "6, ");
    }


    [Test]
    public void Test_10_pic4()
    {
      int i = 0;
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1 + i, 2 + i);
                 AddEdge(graph, 2 + i, 1 + i);

                 AddEdge(graph, 2 + i, 3 + i);
                 AddEdge(graph, 3 + i, 1 + i);

                 AddEdge(graph, 2 + i, 4 + i);
                 AddEdge(graph, 4 + i, 5 + i);
                 AddEdge(graph, 5 + i, 1 + i);

                 AddEdge(graph, 2 + i, 6 + i);
                 AddEdge(graph, 6 + i, 7 + i);
                 AddEdge(graph, 7 + i, 8 + i);
                 AddEdge(graph, 8 + i, 1 + i);
               },
             @"1, 2,", @"1, 2, 3, ", @"1, 2, 4, 5, ", @"1, 2, 6, 7, 8, ");
    }

    [Test]
    public void Test_11_slip()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 4);
                 AddEdge(graph, 4, 5);

                 AddEdge(graph, 5, 1);

                 AddEdge(graph, 5, 6);
                 AddEdge(graph, 6, 1);


                 AddEdge(graph, 5, 9);
                 AddEdge(graph, 9, 10);
                 AddEdge(graph, 10, 11);
                 AddEdge(graph, 11, 1);
               },
             "1, 2, 3, 4, 5, ", "1, 2, 3, 4, 5, 6, ", "1, 2, 3, 4, 5, 9, 10, 11,");
    }

    [Test]
    public void Test_12_slip()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 AddEdge(graph, 0, 0);

                 AddEdge(graph, 0, 1);
                 AddEdge(graph, 1, 0);

                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 4);
                 AddEdge(graph, 4, 5);

                 AddEdge(graph, 5, 6);

                 AddEdge(graph, 6, 7);
                 AddEdge(graph, 7, 8);
                 AddEdge(graph, 8, 9);
                 AddEdge(graph, 9, 10);
                 AddEdge(graph, 10, 1);

                 AddEdge(graph, 5, 11);
                 AddEdge(graph, 11, 6);

                 AddEdge(graph, 5, 12);
                 AddEdge(graph, 12, 13);
                 AddEdge(graph, 13, 6);

                 AddEdge(graph, 10, 14);
                 AddEdge(graph, 14, 15);
                 AddEdge(graph, 15, 16);
                 AddEdge(graph, 16, 11);

                 AddEdge(graph, 10, 17);
                 AddEdge(graph, 17, 18);
                 AddEdge(graph, 18, 1);
               },
             "0, ",
             "0, 1, ",
             "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ",
             "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 18,");
    }
  }
}