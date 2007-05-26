/*
 * Created by: 
 * Created: 27 ����� 2007 �.
 */

using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class LoopIteratorTest : GraphBaseTest
  {
    private static void DoTest(BuildGraph bg, params string[] golds)
    {
      DoTest(bg, false, golds);      
    }

    private static void DoTest(BuildGraph bg, bool filter, params string[] golds)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      MockCallback mcb = new MockCallback();
      if (!filter)
      {
        LoopIterator<IntegerCoordinate, MockCallback> gws =
          new LoopIterator<IntegerCoordinate, MockCallback>(mcb, graph, components, GetFirst(components.Components));

        gws.WidthSearch(NullProgressInfo.INSTANCE, graph.NodesCount, GetFirst(graph.Nodes));
      } else
      {
        LoopIterator<IntegerCoordinate, NonDuplicatedLoopIteratorCallback<IntegerCoordinate,MockCallback>> gws =
          new LoopIterator<IntegerCoordinate, NonDuplicatedLoopIteratorCallback<IntegerCoordinate, MockCallback>>(
            new NonDuplicatedLoopIteratorCallback<IntegerCoordinate, MockCallback>(mcb), graph, components, GetFirst(components.Components));

        gws.WidthSearch(NullProgressInfo.INSTANCE, graph.NodesCount, GetFirst(graph.Nodes));        
      }

      StringBuilder sb = new StringBuilder();
      foreach (List<string> loop in mcb.Loops)
      {
        loop.Reverse();
        foreach (string s in loop)
        {
          sb.Append(s);
          sb.Append(", ");
        }
        sb.AppendLine();
      }
      try
      {
        for (int index = 0; index < mcb.Loops.Count; index++)
        {
          List<string> loop = mcb.Loops[index];
          StringBuilder sbb = new StringBuilder();
          foreach (string s in loop)
          {
            sbb.Append(s);
            sbb.Append(", ");
          }
          Assert.AreEqual(golds[index].Trim(), sbb.ToString().Trim());
        }

        Assert.AreEqual(golds.Length, mcb.Loops.Count, "Incorrect loops count");
      }
      catch
      {
        Console.Error.WriteLine(sb.ToString().Trim());
        throw;
      }
    }

    [Test]
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
               });
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
               }, "3, 2,", "2, 3,");
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
    public void Test_09()
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
               }, true);
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
               }, true, "3, 2,");
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
  }
}