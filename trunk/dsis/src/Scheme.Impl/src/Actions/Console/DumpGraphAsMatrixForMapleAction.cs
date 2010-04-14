using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
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
                     Create(Keys.GetGraphComponents<Q>()),
                     Create(FileKeys.WorkingFolderKey));
    }

    protected sealed override void Apply<T, Q>(Context input, Context output)
    {
      var measure = Keys.GetGraphComponents<Q>().Get(input);
      var folder = FileKeys.WorkingFolderKey.Get(input);

      var name = folder.CreateFileNameFromTemplate("maple-graph-matrix-{0}");

      var graph = measure.Accessor(measure.Components).AsGraph();
      graph.DoGeneric(new Impl<Q>(name));
    }

    private class Impl<Q> : IReadonlyGraphWith<Q> where Q : ICellCoordinate
    {
      private readonly string myName;

      public Impl(string name)
      {
        myName = name;
      }

      public void With<TNode>(IReadonlyGraph<Q, TNode> graph) where TNode : class, INode<Q>
      {
        using (TextWriter tw = File.CreateText(myName))
        {
          tw.WriteLine("with(LinearAlgebra);");
          tw.WriteLine("n:={0};", graph.NodesCount);
          tw.WriteLine("m:=Matrix(");

          using (var rows = new CollectionWriter(tw, "[", ", ", "]"))
          {
            var nodes = new List<TNode>(graph.NodesInternal);
            foreach (var node in nodes)
            {
              using (var cols = rows.SubWriter("[", ", ", "]\r\n"))
              {
                var set = new HashSet<TNode>(graph.Comparer);
                set.UnionWith(graph.GetEdgesInternal(node));

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
}