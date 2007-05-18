using System;
using System.Collections.Generic;
using System.IO;
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

    protected void AssertDump(string gold, params PointGraphNode[] nodes)
    {
      AssertDump(gold, (IEnumerable<PointGraphNode>) nodes);
    }

    protected void AssertDump(string gold, IEnumerable<PointGraphNode> nodes)
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
  }
}