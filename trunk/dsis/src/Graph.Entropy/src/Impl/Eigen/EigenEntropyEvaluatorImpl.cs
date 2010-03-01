using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Eigen
{
  public class EigenEntropyEvaluatorImpl<T>
    where T : ICellCoordinate
  {
    private const int myMaxSteps = 10000;

    private readonly double myEps;
    
    private readonly IReadonlyGraph<T> myGraph;
    private double? myEntropy;

    public EigenEntropyEvaluatorImpl(double eps, IReadonlyGraph<T> graph)
    {
      myEps = eps;
      myGraph = graph;
    }

    public IReadonlyGraph<T> Graph
    {
      get { return myGraph; }
    }

    public double Eps
    {
      get { return myEps; }
    }

    public IGraphEntropy ComputeEntropy()
    {
      if (myEntropy == null)
        myEntropy = DoCompute();

      return new GraphEntropy("Eigen entropy", myEntropy.Value);
    }

    private double DoCompute()
    {
      var steps = myMaxSteps;
      double maxEntropy = 0;

      double eigen = -1;
      double t = 0;
      var v = Create(myGraph, 1);
      double div = myGraph.NodesCount;
      while (Math.Abs(eigen - t) > myEps && steps-- >= 0)
      {
        eigen = t;

        //mul = (|v_n+1|, v_n+1) = A v_n/|v_n|
        //eig_n+1 = |v_n+1|/|v_n| = |A v_n| / |v_n|
        var mul = Multiply(Math.Sqrt(div), myGraph, v);
        v = mul.Second;
        t = mul.First;
        div = mul.First;

        maxEntropy = Math.Max(t, maxEntropy);
      }
      return Math.Log(steps == 0 ? maxEntropy : t, 2)/2;      
    }

    /// <summary>
    /// Computes (|Av/div|, Av/div) where A is Graph, v is Dictionary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="div"></param>
    /// <param name="graph"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    private static Pair<double, Dictionary<INode<T>, double>> Multiply(double div, IReadonlyGraph<T> graph, IDictionary<INode<T>, double> v)
    {
      var v2 = Create(graph);
      double norm = 0;
      foreach (var node in graph.Nodes)
      {
        double t = graph.GetEdges(node).Sum(edge => v[edge]) / div;
        v2.Add(node, t);
        norm += t*t; //All numbers > 0 thus Abs is not necessary
      }
      return new Pair<double, Dictionary<INode<T>, double>>(norm, v2);
    }

    private static Dictionary<INode<T>, double> Create(IReadonlyGraph graph)
    {
      return new Dictionary<INode<T>, double>(graph.NodesCount, EqualityComparerFactory<INode<T>>.GetComparer());
    }

    private static Dictionary<INode<T>, double> Create(IReadonlyGraph<T> graph, double v)
    {
      var vs = Create(graph);
      foreach (var node in graph.Nodes)
      {
        vs[node] = v;
      }
      return vs;
    }
  }
}