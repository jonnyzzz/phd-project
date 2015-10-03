using System;
using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DSIS.Graph.Entropy.Tests
{
  public abstract class EntropyBlackboxTest : GraphBaseTest
  {
    protected virtual double EPS { get { return 1e-3;}}
    protected static bool DEBUG = false;

    protected virtual Constraint AssertEntropy(double expected)
    {
      return Is.EqualTo(expected).Within(EPS);
    }

    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      DEBUG = false;
    }

    protected static Node n(int f, int t)
    {
      return n(f, t, null);
    }

    protected static Node n(int f, int t, double? w)
    {
      return new Node(f, t, w);
    }

    protected struct Node
    {
      public readonly int From;
      public readonly int To;
      public readonly double? Weight;

      public Node(int from, int to, double? weight)
      {
        From = from;
        To = to;
        Weight = weight;
      }

      public override string ToString()
      {
        return string.Format("{0}->{1}", From, To);
      }
    }

    protected virtual void DoTest(string script, double entropy, params Node[] nodes)
    {
      IGraphEntropy evaluator = DoTest(script, nodes);
      evaluator.GetEntropy();

      if (DEBUG)
        Console.Out.WriteLine("l.Result = {0}", evaluator.GetEntropy());

      Assert.That(evaluator.GetEntropy(), AssertEntropy(entropy));
    }

    protected abstract Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> CreateEvaluator(string script, TarjanGraph<IntegerCoordinate> gr, IGraphStrongComponents<IntegerCoordinate> comps);

    protected IGraphEntropy DoTest(string script, params Node[] nodes)
    {
      TarjanGraph<IntegerCoordinate> g = DoBuildGraph(delegate(IGraph<IntegerCoordinate> graph)
                                                        {
                                                          foreach (Node node in nodes)
                                                          {
                                                            AddEdge(graph, node.From, node.To);
                                                          }
                                                        });

      if (DEBUG)
      {
        Console.Out.WriteLine("g.NodesCount = {0}", g.NodesCount);
        Console.Out.WriteLine("g.EdgesCount = {0}", g.EdgesCount);
      }

      IGraphStrongComponents<IntegerCoordinate> c = g.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> eval = CreateEvaluator(script, g, c);
      IGraphMeasure<IntegerCoordinate> j2 = eval.First;
      IEdgeInfo j = eval.Second;

      var mi = new Dictionary<IntegerCoordinate, double>(EqualityComparerFactory<IntegerCoordinate>.GetComparer());

      try
      {
        foreach (Node node in nodes)
        {
          IntegerCoordinate fromC = AddNode(g, node.From).Coordinate;
          IntegerCoordinate toC = AddNode(g, node.To).Coordinate;

          double edge = j.Edge(fromC, toC);

          if (!mi.ContainsKey(fromC))
            mi[fromC] = 0;
          if (!mi.ContainsKey(toC))
            mi[toC] = 0;

          mi[fromC] -= edge;
          mi[toC] += edge;

          double? w = node.Weight;
          if (w != null)
            Assert.AreEqual(w.Value, edge, EPS, "Node assert value failed for node {0}", node);
        }
      }
      catch(Exception e)
      {
        DEBUG = true;
        throw new Exception(e.Message, e);
      }
      finally
      {
        if (DEBUG)
        {
          foreach (Node node in nodes)
          {
            IntegerCoordinate fromC = AddNode(g, node.From).Coordinate;
            IntegerCoordinate toC = AddNode(g, node.To).Coordinate;

            Console.Out.WriteLine("{0}->{1} {2}", fromC, toC, j.Edge(fromC, toC));
          }
        }
      }

      try
      {
        foreach (Node node in nodes)
        {
          IntegerCoordinate fromC = AddNode(g, node.From).Coordinate;
          IntegerCoordinate toC = AddNode(g, node.To).Coordinate;

          double edge = j.Edge(fromC, toC);

          if (!mi.ContainsKey(fromC))
            mi[fromC] = 0;
          if (!mi.ContainsKey(toC))
            mi[toC] = 0;

          mi[fromC] -= edge;
          mi[toC] += edge;
        }

        foreach (KeyValuePair<IntegerCoordinate, double> pair in mi)
        {
          Assert.AreEqual(0, pair.Value, EPS, "Balance for node {0}", pair.Key);
        }
      }
      catch (Exception e)
      {
        DEBUG = true;
        throw new Exception(e.Message, e);
      }
      finally
      {
        if (DEBUG)
        {
          Console.Out.WriteLine();
          foreach (KeyValuePair<IntegerCoordinate, double> pair in mi)
          {
            Console.Out.WriteLine("{0} -> {1}", pair.Key, pair.Value);
          }
          Console.Out.WriteLine();
        }
      }

      return j2;
    }

    protected interface IEdgeInfo
    {
      double Edge(IntegerCoordinate from, IntegerCoordinate to);
    }

    protected static double L(double v)
    {
      return v*Math.Log(v)/Math.Log(2);
    }

    protected class GraphMeasureEdgeInfo<TPair> : IEdgeInfo 
      where TPair : PairBase<IntegerCoordinate>       
    {
      private readonly GraphMeasure<IntegerCoordinate, TPair> myMeasure;
      private readonly Create myFactory;

      public GraphMeasureEdgeInfo(GraphMeasure<IntegerCoordinate, TPair> measure, Create factory)
      {
        myMeasure = measure;
        myFactory = factory;
      }

      public delegate TPair Create(IntegerCoordinate from, IntegerCoordinate to);

      public double Edge(IntegerCoordinate from, IntegerCoordinate to)
      {
        return myMeasure.M[myFactory(from, to)] / myMeasure.Norm;
      }
    }
  }
}