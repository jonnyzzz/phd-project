using System.Collections.Generic;
using System.IO;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphAsMatrixForMapleAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GraphComponents<Q>()),
                     Create(FileKeys.WorkingFolderKey));
    }

    protected sealed override void Apply<T, Q>(Context input, Context output)
    {
      var measure = Keys.GraphComponents<Q>().Get(input);
      var folder = FileKeys.WorkingFolderKey.Get(input);

      var name = folder.CreateFileNameFromTemplate("maple-graph-matrix-{0}");

      var graph = measure.AsGraph(measure.Components);
      using (TextWriter tw = File.CreateText(name))
      {
        tw.WriteLine("with(LinearAlgebra);");
        tw.WriteLine("n:={0};", graph.NodesCount);
        tw.WriteLine("m:=Matrix(");

        using (var rows = new CollectionWriter(tw, "[", ", ", "]"))
        {
          var nodes = new List<INode<Q>>(graph.Nodes);
          foreach (var node in nodes)
          {
            using (var cols = rows.SubWriter("[", ", ", "]\r\n"))
            {
              var set = new Hashset<INode<Q>>();
              set.AddRange(graph.GetEdges(node));

              foreach (var line in nodes)
                cols.Write(set.Contains(line) ? "1" : "0");
            }
          }
        }
        tw.WriteLine(");");
        tw.WriteLine("ans := evalf(Eigenvalues(m));");        
      }
    }
  }
}