using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Eigen
{
  public class EigenEntropyEvaluatorImpl : IEntropyEvaluator
  {
    public double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
      where T : ICellCoordinate<T>
    {
      Dictionary<INode<T>, double> v = Create(graph, 1);

      double div = graph.NodesCount;
      while(true)
      {
        Pair<double, Dictionary<INode<T>, double>> mul = Multiply(div, graph, v);
        v = mul.Second;
        div = mul.First;
      }

      return 0;
    }

    private static Pair<double, Dictionary<INode<T>, double>> Multiply<T>(double div, IGraph<T> graph, Dictionary<INode<T>, double> v) where T : ICellCoordinate<T>
    {
      Dictionary<INode<T>, double> v2 = Create(graph, 0);
      double norm = 0;
      foreach (INode<T> node in graph.Nodes)
      {
        double t = 0;
        foreach (INode<T> edge in graph.GetEdges(node))
        {
          t += v[edge]; //* 1
        }
        t /= div;
        v2[node] += t;
        norm += t; //All numbers > 0 thus Abs is not necessary
      }
      return new Pair<double, Dictionary<INode<T>, double>>(norm, v2);
    }

    private static Dictionary<INode<T>, double> Create<T>(IGraph<T> graph) where T : ICellCoordinate<T>
    {
      return new Dictionary<INode<T>, double>(graph.NodesCount, EqualityComparerFactory<INode<T>>.GetComparer());
    }

    private static Dictionary<INode<T>, double> Create<T>(IGraph<T> graph, double v) where T : ICellCoordinate<T>
    {
      Dictionary<INode<T>, double> vs = Create(graph);
      foreach (INode<T> node in graph.Nodes)
      {
        vs[node] = v;
      }
      return vs;
    }
  }
}
