using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract.Algorithms
{
  public static partial class GraphAlgorithms
  {
    public static string Dump(this IGraph graph)
    {
      var sw = new StringWriter();
      Dump(graph, sw);
      return sw.ToString();
    }

    public static void Dump(this IGraph graph, TextWriter tw)
    {
      var g = new DumpGraph(tw);
      graph.DoGeneric(g);
    }

    private class DumpGraph : IGraphWith
    {
      private readonly TextWriter myWriter;

      public DumpGraph(TextWriter myWriter)
      {
        this.myWriter = myWriter;
      }

      public void With<TCell, TNode>(IGraph<TCell, TNode> graph) where TCell : ICellCoordinate where TNode : Node<TNode, TCell>
      {
        Dump(graph, myWriter);
      }

      private static void Dump<TNode, TCell>(IGraph<TCell, TNode> graph, TextWriter tw)
        where TCell : ICellCoordinate
        where TNode : Node<TNode, TCell>
      {
        tw.WriteLine(graph);
        var ids = new Dictionary<TNode, int>();
        int lastId = 0;
        foreach (TNode node in graph.Nodes)
        {
          int id;
          if (!ids.TryGetValue(node, out id))
          {
            id = ++lastId;
            ids[node] = id;
          }

          tw.Write("  {0} -> {{ ", id);

          foreach (TNode pair in node.Edges)
          {
            int id2;
            if (!ids.TryGetValue(pair, out id2))
            {
              id2 = ++lastId;
              ids[pair] = id2;
            }

            tw.Write("{0}, ", id2);
          }

          tw.WriteLine(" }}");
        }
        tw.WriteLine("Finished!\r\n");
      }

    }
  }
}