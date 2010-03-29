using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;
using System.Linq;

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
      {
        var proxy = new Proxy(myEps);
        myGraph.DoGeneric(proxy);
        myEntropy = proxy.Result;
      }

      return new GraphEntropy("Eigen entropy", myEntropy.Value);
    }

    private class Proxy : IReadonlyGraphWith<T>
    {
      private readonly double myEps;
      public double Result { get; private set; }

      public Proxy(double eps)
      {
        myEps = eps;
      }

      public void With<TNode>(IReadonlyGraph<T, TNode> graph) where TNode : class, INode<T>
      {
        Result = new Impl<TNode>(graph, myEps).DoCompute();
      }
    }

    private class Impl<TNode> where TNode: class, INode<T>
    {
      private readonly IReadonlyGraph<T, TNode> myGraph;
      private readonly double myEps;

      public Impl(IReadonlyGraph<T, TNode> graph, double eps)
      {
        myGraph = graph;
        myEps = eps;
      }

      public double DoCompute()
      {
        var steps = myMaxSteps;
        double maxEntropy = 0;

        double eigen = -1;
        double t = 0;
        var v = Create(1);
        double div = myGraph.NodesCount;
        while (Math.Abs(eigen - t) > myEps && steps-- >= 0)
        {
          eigen = t;

          //mul = (|v_n+1|, v_n+1) = A v_n/|v_n|
          //eig_n+1 = |v_n+1|/|v_n| = |A v_n| / |v_n|
          var mul = Multiply(Math.Sqrt(div), v);
          v = mul.Second;
          t = mul.First;
          div = mul.First;

          maxEntropy = Math.Max(t, maxEntropy);
        }
        return Math.Log(steps == 0 ? maxEntropy : t, 2) / 2;
      }

      /// <summary>
      /// Computes (|Av/div|, Av/div) where A is Graph, v is Dictionary
      /// </summary>
      /// <param name="div"></param>
      /// <param name="v"></param>
      /// <returns></returns>
      private Pair<double, Dictionary<TNode, double>> Multiply(double div, IDictionary<TNode, double> v)
      {
        var v2 = Create();
        double norm = 0;
        foreach (var node in myGraph.NodesInternal)
        {
          double t = myGraph.GetEdgesInternal(node).Sum(edge => v[edge]) / div;
          v2.Add(node, t);
          norm += t * t; //All numbers > 0 thus Abs is not necessary
        }
        return new Pair<double, Dictionary<TNode, double>>(norm, v2);
      }

      private Dictionary<TNode, double> Create()
      {
        return new Dictionary<TNode, double>(myGraph.NodesCount, myGraph.Comparer);
      }

      private Dictionary<TNode, double> Create(double v)
      {
        var vs = Create();
        foreach (var node in myGraph.NodesInternal)
        {
          vs[node] = v;
        }
        return vs;
      }
    }
  }
}