using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;
using System.Linq;
using NUnit.Framework;

namespace DSIS.Graph.Tests.FS
{
  public class TestContextWithGraph<TCell, TNode> : ITestContextWithGraph<TCell>
    where TCell : ICellCoordinate 
    where TNode : class, INode<TCell>
  {
    private readonly TestContext<TCell> myHost;
    private readonly IReadonlyGraph<TCell, TNode> myGraph;

    public TestContextWithGraph(TestContext<TCell> host, IReadonlyGraph<TCell, TNode> graph)
    {
      myHost = host;
      myGraph = graph;
    }
    private TCell Convert(int i)
    {
      return myHost.Convert(i);
    }

    private int Convert(TCell node)
    {
      return myHost.Convert(node);
    }

    private int Convert(TNode node)
    {
      return Convert(node.Coordinate);
    }

    public void CheckBuiltGraphEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      var dict = edges.ToDictionary(x => x.First, x=>new HashSet<int>(x.Second));
      
      //Check iterators first
      foreach (var node in myGraph.NodesInternal.ToArray())
      {
        var nodeId = Convert(node);
        //Exception if there was no such node in dict
        var outgoing = new HashSet<int>(dict[nodeId]);
        foreach (var dest in myGraph.GetEdgesInternal(node).ToArray())
        {
          Assert.IsNotNull(dest, "Siblings of {0} is null", nodeId);

          Assert.IsTrue(outgoing.Remove(Convert(dest)), "Edges {0}->{1} sould not be contained in graph", nodeId, Convert(dest));
        }
        Assert.IsTrue(outgoing.IsEmpty(), "Graph should contain: {0}", outgoing.Sort((a,b)=>a<b ?-1 :a>b? 1 : 0).JoinString(to=>string.Format("{0}->{1}", nodeId, to), ", "));

        //Remove node
        dict.Remove(nodeId);
      }

      Assert.IsTrue(dict.IsEmpty(), "Graph should contain nodes: ", dict.Keys.JoinString(", "));
    }

    public void DumpGraph()
    {
      foreach (var node in myGraph.NodesInternal)
      {
        Console.Out.WriteLine("node = {0}", node.Coordinate);
        foreach (var to in myGraph.GetEdgesInternal(node))
        {
          Console.Out.WriteLine(" -> {0}", to.Coordinate);
        }
      }
    }

    public void CheckDataHolder<T>(IEnumerable<Pair<int, T>> data)
    {
      using(var holder = myGraph.CreateDataHolder(x=>default(T)))
      {
        foreach (var pair in data)
        {
          var node = myGraph.Find(Convert(pair.First));
          Assert.IsNotNull(node);

          Assert.IsFalse(holder.HasData(node));
          holder.SetData(node, pair.Second);
        }

        foreach (var pair in data)
        {
          var node = myGraph.Find(Convert(pair.First));
          Assert.IsNotNull(node);

          Assert.IsTrue(holder.HasData(node));
          var d = holder.GetData(node);
          Assert.AreEqual(pair.Second, d);
        }
      }
    }
  }
}