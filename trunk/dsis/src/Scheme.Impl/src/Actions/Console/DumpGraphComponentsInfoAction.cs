using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphComponentsInfoAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return new[] {Create(Keys.GetGraphComponents<Q>())};
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraphStrongComponents<Q> gr = Keys.GetGraphComponents<Q>().Get(input);

      var sb = new StringBuilder();
      sb.AppendFormat("Components: {0}", gr.ComponentCount).AppendLine();
      sb.Append("Component's Nodes-Edges: ");
      long totalEdges = 0, totalNodes = 0;
      foreach (var info in gr.Components.Select(x=>x.Enum()))
      {
        long nodes = 0;
        long edges = 0;
        foreach (var node in gr.GetNodes(info))
        {
          nodes++;
          edges += gr.GetEdgesWithFilteredEdges(node, info).Count();          
        }
        totalEdges += edges;
        totalNodes += nodes;
        sb.AppendFormat("{0}-{1}, ", nodes, edges);        
      }
      sb.AppendLine();
      sb.AppendFormat("Components total: Nodes: {0}, Edges: {1}", totalNodes, totalEdges);
      Logger.Instance(input).Write(sb.ToString());
    }
  }
}