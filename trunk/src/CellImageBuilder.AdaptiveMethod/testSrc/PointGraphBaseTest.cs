using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using DSIS.Core.Util;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class PointGraphBaseTest
  {
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

    private void DumpGraph(TextWriter tw, IEnumerable<PointGraphNode> initialNodes, bool dumpPoints)
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

      if (dumpPoints)
      {
        tw.WriteLine("Points:");

        foreach (PointGraphNode node in initialNodes)
        {
          tw.Write("{0} -> ", marker.Id(node));          
          foreach (double d in node.PointX)
          {
            tw.Write("{0}, ", d.ToString(CultureInfo.InvariantCulture));
          }
          tw.WriteLine();
        }
        tw.WriteLine("Done.");
      }
    }

    protected void AssertDump(string gold, params PointGraphNode[] nodes)
    {
      AssertDump(gold, (IEnumerable<PointGraphNode>) nodes);
    }

    private void AssertDumpInternal(string actual, string gold)
    {
      try
      {
        string expected;
        using (
          TextReader tr =
            new StreamReader(GetType().Assembly.GetManifestResourceStream(
                               "DSIS.CellImageBuilder.AdaptiveMethod.testSrc.gold." + gold + ".txt")))
          expected = tr.ReadToEnd();


        Assert.AreEqual(expected, actual);
      }
      catch
      {
        Console.Out.WriteLine(actual);
        throw;
      }

    }

    protected void AssertDump(string gold, IEnumerable<PointGraphNode> nodes)
    {
      AssertDumpInternal(DumpGraphConnections(nodes, false), gold);
    }

    private string DumpGraphConnections(IEnumerable<PointGraphNode> nodes, bool withPoints)
    {
      string actual;
      using (StringWriter tw = new StringWriter())
      {
        DumpGraph(tw, nodes, withPoints);
        actual = tw.ToString();
      }
      return actual;
    }

    protected void AssertDumpWithCoordinates(string gold, IEnumerable<PointGraphNode> nodes)
    {
      AssertDumpInternal(DumpGraphConnections(nodes, true), gold);
    }
  }
}