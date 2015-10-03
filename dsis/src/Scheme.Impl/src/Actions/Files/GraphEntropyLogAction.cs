using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class GraphEntropyLogAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(FileKeys.WorkingFolderKey), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      string dir = FileKeys.WorkingFolderKey.Get(input).Path;
      string file = Path.Combine(dir, "graph-entropy.log");

      //todo:!Not optimal!
      IGraphStrongComponents<Q> components = Keys.GraphComponents<Q>().Get(input);
      IGraph<Q> graph = components.AsGraph(components.Components);
      
      DumpEntropy(graph, file, false);

      while(graph.CoordinateSystem.Subdivision[0] > 1)
      {
        ICellCoordinateSystemProjector<Q> proj = graph.CoordinateSystem.Project(CollectionUtil.Fill(graph.CoordinateSystem.Dimension, 2L));
        graph = graph.Project(proj);
        DumpEntropy(graph, file, true);
      }
    }

    private static void DumpEntropy(IGraph graph, string file, bool isProject)
    {
      int nodes = graph.NodesCount;
      int edges = graph.EdgesCount;

      double factor = edges/(double)nodes;
      double value = Math.Log(factor, 2);
      double value2 = Math.Log(factor);

      string text = string.Format("{0}  nodes={1} edges={2} ln={3} {4} {5}", value.ToString(CultureInfo.InvariantCulture), nodes, edges, value2, isProject ? "[Project]" : string.Empty, Environment.NewLine);

      File.AppendAllText(file, text);
    }
  }
}