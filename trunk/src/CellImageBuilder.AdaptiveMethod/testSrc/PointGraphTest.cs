using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Function.Mock;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  [TestFixture]
  public class PointGraphTest
  {
    private IFunction<double> myFunction;
    private double[] myEps;
    private PointGraph myGraph;

    [SetUp]
    public void SetUp()
    {
      myFunction = new MockFunction<double>(1, delegate(double ins) { return ins; });
      myEps = new double[] {1};
      myGraph = new PointGraph(myFunction, myEps);
    }

    private void CollectNodes(PointGraphNode node, Hashset<PointGraphNode> nodes)
    {
      nodes.Add(node);
      foreach (PointGraphNode edge in node.Edges)
      {
        nodes.Add(edge);
        if (!nodes.Contains(edge))
        {
          CollectNodes(edge, nodes);
        }
      }
    }

    private void DumpGraph(TextWriter tw, IEnumerable<PointGraphNode> initialNodes)
    {
      Hashset<PointGraphNode> nodes = new Hashset<PointGraphNode>();

      foreach (PointGraphNode node in initialNodes)
      {
        CollectNodes(node, nodes);
      }

      ObjectMarker<PointGraphNode> marker = new ObjectMarker<PointGraphNode>();
      foreach (PointGraphNode node in initialNodes)
      {
        marker.Id(node);
      }

      foreach (PointGraphNode node in nodes)
      {
        marker.Id(node);
      }

      tw.WriteLine("Graph: ");
      foreach (PointGraphNode node in nodes)
      {
        tw.Write("{0} -> ", marker.Id(node));

        foreach (PointGraphNode edge in node.Edges)
        {
          tw.Write("{0}, ", marker.Id(edge));
        }
        tw.WriteLine();
      }
      tw.WriteLine("Done");
    }

    private void AssertDump(string gold, params PointGraphNode[] nodes)
    {
      AssertDump(nodes, gold);
    }

    private void AssertDump(IEnumerable<PointGraphNode> nodes, string gold)
    {
      string actual = "Failed to dump";
      try
      {
        using (StringWriter tw = new StringWriter())
        {
          DumpGraph(tw, nodes);
          actual = tw.ToString();
        }

        string expected;
        using (
          TextReader tr =
            new StreamReader(GetType().Assembly.GetManifestResourceStream(GetType(), "gold." + gold + ".txt")))
          expected = tr.ReadToEnd();


        Assert.AreEqual(expected, actual);
      }
      catch
      {
        Console.Out.WriteLine(actual);
        throw;
      }
    }


    [Test]
    public void Test_01()
    {
      PointGraphNode n1 = myGraph.CreateNode(1);
      PointGraphNode n2 = myGraph.CreateNode(2);

      double[] ds = new double[1];
      myGraph.ComputeDistance(n1, n2, ds);

      Assert.AreEqual(1, ds[0], 1e-8);
    }

    [Test]
    public void Test_02()
    {
      PointGraphNode n1 = myGraph.CreateNode(0);
      PointGraphNode n2 = myGraph.CreateNode(2);

      Assert.IsFalse(myGraph.CheckDistance(n1, n2));
    }

    [Test]
    public void Test_03()
    {
      PointGraphNode n1 = myGraph.CreateNode(0);
      PointGraphNode n2 = myGraph.CreateNode(2);
      myGraph.AddEdge(n1, n2);

      AssertDump("test_03", n1, n2);      
    }

    [Test]
    public void Test_04_split()
    {
      PointGraphNode n1 = myGraph.CreateNode(0);
      PointGraphNode n2 = myGraph.CreateNode(2);
      myGraph.AddEdge(n1, n2);

      PointGraphNode m = myGraph.Subdivide(n1, n2).First;

      Assert.AreEqual(1, m.PointX[0], 1e-8);
      Assert.AreEqual(0, n1.PointX[0], 1e-8);
      Assert.AreEqual(2, n2.PointX[0], 1e-8);

      AssertDump("test_04", n1, n2);      
    }

    [Test]
    public void Test_05()
    {
      PointGraphNode n1 = myGraph.CreateNode(0);
      PointGraphNode n2 = myGraph.CreateNode(2);
      PointGraphNode n3 = myGraph.CreateNode(5);
      myGraph.AddEdge(n1, n2);
      myGraph.AddEdge(n1, n3);
      myGraph.AddEdge(n2, n3);
 
      AssertDump("test_05", n1, n2, n3);      
    }

    [Test]
    public void Test_06_split()
    {
      PointGraphNode n1 = myGraph.CreateNode(0);
      PointGraphNode n2 = myGraph.CreateNode(2);
      PointGraphNode n3 = myGraph.CreateNode(5);
      myGraph.AddEdge(n1, n2);
      myGraph.AddEdge(n1, n3);
      myGraph.AddEdge(n2, n3);

      PointGraphNode m = myGraph.Subdivide(n1, n2).First;

      Assert.AreEqual(1, m.PointX[0], 1e-8);
      Assert.AreEqual(0, n1.PointX[0], 1e-8);
      Assert.AreEqual(2, n2.PointX[0], 1e-8);

 
      AssertDump("test_06", n1, n2, n3);      
    }
  }
}