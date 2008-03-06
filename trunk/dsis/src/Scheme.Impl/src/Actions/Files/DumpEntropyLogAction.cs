using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class MeasureEntropyLogAction : IntegerCoordinateSystemActionBase2  
  {
    private string myPrefix;


    public MeasureEntropyLogAction() : this(string.Empty)
    {
    }

    public MeasureEntropyLogAction(string prefix)
    {
      myPrefix = prefix;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(FileKeys.WorkingFolderKey), Create(Keys.GraphMeasure<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      string dir = FileKeys.WorkingFolderKey.Get(input).Path;
      string file = dir + "-entropy.log";

      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      double value = measure.GetEntropy();

      string text = string.Format("{0} edges={1} [{2}] {3}", value.ToString(CultureInfo.InvariantCulture), CollectionUtil.Count(measure.GetMeasureNodes()), myPrefix, Environment.NewLine);
      File.AppendAllText(file, text);
    }
  }
  
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
      
      int nodes = graph.NodesCount;
      int edges = graph.EdgesCount;

      double value = Math.Log(edges/nodes);

      string text = string.Format("{0}  nodes={1} edges={2}{3}", value.ToString(CultureInfo.InvariantCulture), nodes, edges, Environment.NewLine);

      File.AppendAllText(file, text);
    }
  }
}