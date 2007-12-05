using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Eigen
{
  public class EigenEntropyEvaluatorImpl<T> : IGraphEntropy
    where T : ICellCoordinate<T>
  {
    private readonly double myEps;
    private readonly IGraph<T> myGraph;
    private double? myEntropy = null;

    public EigenEntropyEvaluatorImpl(double eps, IGraph<T> graph)
    {
      myEps = eps;
      myGraph = graph;
    }

    #region IGraphEntropy Members

    public double GetEntropy()
    {
      return myEntropy.Value;
    }

    #endregion

    public IGraphEntropy ComputeEntropy()
    {
      if (myEntropy == null)
        myEntropy = DoCompute();

      return this;
    }

    private double DoCompute()
    {
      double eigen = -1;
      double t = 0;
      Dictionary<INode<T>, double> v = Create(myGraph, 1);
      double div = myGraph.NodesCount;
      while (Math.Abs(eigen - t) > myEps)
      {
        eigen = t;

        //mul = (|v_n+1|, v_n+1) = A v_n/|v_n|
        //eig_n+1 = |v_n+1|/|v_n| = |A v_n| / |v_n|
        Pair<double, Dictionary<INode<T>, double>> mul = Multiply(Math.Sqrt(div), myGraph, v);
        v = mul.Second;
        t = mul.First;
        div = mul.First;
      }
      eigen = t;
      return Math.Log(eigen)/Math.Log(2)/2;
    }

    /// <summary>
    /// Computes (|Av/div|, Av/div) where A is Graph, v is Dictionary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="div"></param>
    /// <param name="graph"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    private static Pair<double, Dictionary<INode<T>, double>> Multiply(double div, IGraph<T> graph,
                                                                       IDictionary<INode<T>, double> v)
    {
      Dictionary<INode<T>, double> v2 = Create(graph);
      double norm = 0;
      foreach (INode<T> node in graph.Nodes)
      {
        double t = 0;
        foreach (INode<T> edge in graph.GetEdges(node))
        {
          t += v[edge]; //* 1
        }
        t /= div;
        v2.Add(node, t);
        norm += t*t; //All numbers > 0 thus Abs is not necessary
      }
      return new Pair<double, Dictionary<INode<T>, double>>(norm, v2);
    }

    private static Dictionary<INode<T>, double> Create(IGraph<T> graph)
    {
      return new Dictionary<INode<T>, double>(graph.NodesCount, EqualityComparerFactory<INode<T>>.GetComparer());
    }

    private static Dictionary<INode<T>, double> Create(IGraph<T> graph, double v)
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