/*
 * Created by: 
 * Created: 27 марта 2007 г.
 */

using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Tests;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class LoopIteratorTest : LoopIteratorTestBase
  {
    protected override ILoopIterator CreateLoopIterator(TarjanGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components, ILoopIteratorCallback<IntegerCoordinate> mcb, IStrongComponentInfo firstComponent)
    {
      return new LoopIteratorFirst<IntegerCoordinate>(mcb, components, firstComponent, new LoopIterator<IntegerCoordinate>(graph, components, firstComponent));
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
                 //         1
                 //      /      \
                 //     2  <->  3
                 //   

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
                 //         1
                 //      /    \\
                 //     2  <->  3
                 //   

                 AddEdge(graph, 1, 2); 
                 AddEdge(graph, 1, 3); 
                 AddEdge(graph, 3, 2); 
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 1);
               }, "1, 3, ", "3, 2, ", "1, 2, 3, ", "2, 3,"
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

    [Test]
    public void Test_08()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 //         1
                 //      /    \\
                 //     2  <->  3
                 //    /       /
                 //    4 <-> 5
                 //          |
                 //          6 -> 1

                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 1, 3);
                 AddEdge(graph, 3, 2);
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 1);
                 AddEdge(graph, 4, 5);
                 AddEdge(graph, 2, 4);
                 AddEdge(graph, 5, 4);
                 AddEdge(graph, 5, 6);
                 AddEdge(graph, 3, 5);
                 AddEdge(graph, 6, 1);

               }, 
             "1, 3, ", 
             "3, 2, ", 
             "1, 2, 3, ", 
             "2, 3, ", 
             "5, 4, ", 
             "1, 3, 5, 6, ", 
             "4, 5, ", 
             "4, 5, ", 
             "5, 4, ", 
             "1, 2, 3, 5, 6, ", 
             "1, 2, 4, 5, 6, ", 
             "1, 3, 2, 4, 5, 6,");
    }
  
    [Test]
    public void Test_10()
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
    public void Test_11()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 //         1
                 //      /      \
                 //     2  <->  3
                 //   

                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 1, 3);
                 AddEdge(graph, 3, 2);
                 AddEdge(graph, 2, 3);
               }, true, "2, 3,");
    }

    [Test]
    public void Test_12()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 //         1
                 //      /    \\
                 //     2  <->  3
                 //   

                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 1, 3);
                 AddEdge(graph, 3, 2);
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 1);
               }, true, "1, 3, ", "3, 2, ", "1, 2, 3, ");
    }

    [Test]
    public void Test_13()
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
               },true, "1, 2, 3, 5,", "2, 3, 8, 7, 6,");
    }

    [Test]
    public void Test_14()
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
               }, true, "1, 2,", "1, 2, 3,", "1, 2, 3, 5,", "2, 3, 8, 7, 6,");
    }

    [Test]
    public void Test_15()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 //         1
                 //      /    \\
                 //     2  <->  3
                 //    /       /
                 //    4 <-> 5
                 //          |
                 //          6 -> 1

                 AddEdge(graph, 1, 2);
                 AddEdge(graph, 1, 3);
                 AddEdge(graph, 3, 2);
                 AddEdge(graph, 2, 3);
                 AddEdge(graph, 3, 1);
                 AddEdge(graph, 4, 5);
                 AddEdge(graph, 2, 4);
                 AddEdge(graph, 5, 4);
                 AddEdge(graph, 5, 6);
                 AddEdge(graph, 3, 5);
                 AddEdge(graph, 6, 1);

               }, true,
             "1, 3, ",
             "3, 2, ",
             "1, 2, 3, ",
             "5, 4, ",
             "1, 3, 5, 6, ",
             "1, 2, 3, 5, 6, ",
             "1, 2, 4, 5, 6, ",
             "1, 3, 2, 4, 5, 6,");
    }

    [Test]
    public void Test_16()
    {
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 //       /  3 -        \
                 // 1 - 2 -  4 - 6 - 7 - 8 - 11 - 1
                 //       \  5 - 9 - 10 /
                 //          12 -13- 14

                 AddEdge(graph, 1,2);
                 AddEdge(graph, 2,3);
                 AddEdge(graph, 2,4);
                 AddEdge(graph, 2,5);
                 AddEdge(graph, 3,8);
                 AddEdge(graph, 4,6);
                 AddEdge(graph, 6,7);
                 AddEdge(graph, 7,8);
                 AddEdge(graph, 5,9);
                 AddEdge(graph, 9,10);
                 AddEdge(graph, 10, 8);
                 AddEdge(graph, 8, 11);
                 AddEdge(graph, 11, 1);
                 AddEdge(graph, 2, 12);
                 AddEdge(graph, 12, 13);
                 AddEdge(graph, 13, 14);
                 AddEdge(graph, 14, 8);
               }, true,               
             "1, 2, 3, 8, 11, ", 
             "1, 2, 4, 6, 7, 8, 11, ",
             "1, 2, 12, 13, 14, 8, 11, ", 
             "1, 2, 5, 9, 10, 8, 11,");
    }
    
    [Test]
    public void Test_17()
    {
      List<string> result = new List<string>();
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 const int MAX = 100;
                 string s = "";
                 for (int i = 0; i < MAX; i++)
                 {
                   AddEdge(graph, i, (i + 1)%MAX);
                   s += i + ", ";
                 }
                 result.Add(s);
               }, true,
             delegate { return result.ToArray(); });
    }    

    [Test]
    public void Test_18()
    {
      List<string> result = new List<string>();
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {
                 const int MAX = 1000;
                 string s = "";
                 for (int i = 0; i < MAX; i++)
                 {
                   AddEdge(graph, i, (i + 1)%MAX);
                   s += i + ", ";
                 }
                 result.Add(s);
               }, true,
             delegate { return result.ToArray(); });
    }

    [Test][Ignore("Fix me")]
    public void Test_19()
    {
      List<string> result = new List<string>();
      DoTest(delegate(IGraph<IntegerCoordinate> graph)
               {                 
                 const int MAX = 1000;
                 string s = "";
                 for (int i = 1; i <= MAX; i++)
                 {
                   AddEdge(graph, 0, i);
                   AddEdge(graph, i, MAX + 1);
                   s += i + ", ";
                 }
                 AddEdge(graph, MAX + 1, 0);
                 result.Add(s);
               }, true,
             delegate { return result.ToArray(); });
    }
  }
}