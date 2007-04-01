/*
 * Created by: 
 * Created: 27 марта 2007 г.
 */

using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.IntegerCoordinates;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class GraphWeightSearchTest : GraphBaseTest
  {
    private static void DoTest(BuildGraph bg, params string[] golds)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      MockCallback mcb = new MockCallback();
      GraphWeightSearch<IntegerCoordinate, MockCallback> gws = new GraphWeightSearch<IntegerCoordinate, MockCallback>(mcb, graph, components, GetFirst(components.Components));

      gws.WidthSearch(NullProgressInfo.INSTANCE, graph.NodesCount, GetFirst(graph.Nodes));

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
                 INode<IntegerCoordinate> n1 = graph.AddNode(new IntegerCoordinate(1));
                 INode<IntegerCoordinate> n2 = graph.AddNode(new IntegerCoordinate(2));
                 INode<IntegerCoordinate> n3 = graph.AddNode(new IntegerCoordinate(3));
                 INode<IntegerCoordinate> n4 = graph.AddNode(new IntegerCoordinate(4));

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
                 INode<IntegerCoordinate> n1 = graph.AddNode(new IntegerCoordinate(1));
                 INode<IntegerCoordinate> n2 = graph.AddNode(new IntegerCoordinate(2));
                 INode<IntegerCoordinate> n3 = graph.AddNode(new IntegerCoordinate(3));
                 INode<IntegerCoordinate> n4 = graph.AddNode(new IntegerCoordinate(4));

                 graph.AddEdgeToNode(n1, n2);
                 graph.AddEdgeToNode(n2, n3);
                 graph.AddEdgeToNode(n3, n4);
                 graph.AddEdgeToNode(n4, n1);
               }, "1, 2, 3, 4,");
    }

    [Test][Ignore("Missed by algorith idea")]
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
  }
}