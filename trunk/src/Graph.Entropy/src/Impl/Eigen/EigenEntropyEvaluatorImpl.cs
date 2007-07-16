using System;
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
      double eigen = -1;
      double t = 0;

      double div = graph.NodesCount;
      while (Math.Abs(eigen - t) > 1e-4)
      {
        eigen = t;

        //mul = (|v_n+1|, v_n+1) = A v_n/|v_n|
        //eig_n+1 = |v_n+1|/|v_n| = |A v_n| / |v_n|        
        Pair<double, Dictionary<INode<T>, double>> mul = Multiply(div, graph, v);
        v = mul.Second;
       
        t = div/mul.First;
        div = mul.First;
      }
      eigen = t;
      return eigen;
    }

    public double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph,
                                                   IGraphStrongComponents<T> comps) where T : ICellCoordinate<T>
    {
      throw new NotImplementedException();
    }

    public double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph,
                                                   IGraphStrongComponents<T> comps, int limit)
      where T : ICellCoordinate<T>
    {
      throw new NotImplementedException();
    }


    /// <summary>
    /// Computes (|Av/div|, Av/div) where A is Graph, v is Dictionary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="div"></param>
    /// <param name="graph"></param>
    /// <param name="v"></param>
    /// <returns></returns>
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
