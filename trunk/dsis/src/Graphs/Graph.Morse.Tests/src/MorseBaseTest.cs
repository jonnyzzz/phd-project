using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Core.Util;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  public class MorseBaseTest
  {
    [SetUp]
    public void SetUp()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-us");
    }

    protected static void DoTest(double value, BuildGraph bg)
    {
      DoTest(1e-8, value, bg);
    }

    protected static void DoTest(double eps, double value, BuildGraph bg)
    {
      var mss = new MockSystemSpace(1, 0, 1, 1000);
      IIntegerCoordinateSystem<IntegerCoordinate> ics = IntegerCoordinateSystemFactory.Create(mss);
      var graph = new TarjanGraph<IntegerCoordinate>(ics);
      var costs = new Dictionary<INode<IntegerCoordinate>, double>(EqualityComparerFactory<INode<IntegerCoordinate>>.GetComparer());

      var ctx = new CostContext(graph, costs);

      bg(ctx);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      Assert.IsTrue(components.ComponentCount > 0, "No components");
      Assert.IsTrue(components.ComponentCount == 1, "Only one component possible");

      var eval = new MorseEvaluator<TarjanNode<IntegerCoordinate>>(
        new MorseEvaluatorOptions {Eps = eps},
        new MorseStrongComponentGraph<TarjanNode<IntegerCoordinate>, IntegerCoordinate>(graph), new NegativeCost<INode<IntegerCoordinate>>(ctx));
      
      var compute = eval.Minimize().Negative();
      Assert.AreEqual(value, compute.Value, 1e-5);
    }

    protected delegate void BuildGraph(CostContext ctx);

    protected class Context
    {
      private readonly IGraph<IntegerCoordinate> myGraph;

      public Context(IGraph<IntegerCoordinate> graph)
      {
        myGraph = graph;
      }

      public virtual INode<IntegerCoordinate> AddNode(int i)
      {
        return myGraph.AddNode(((IIntegerCoordinateSystem<IntegerCoordinate>) myGraph.CoordinateSystem).Create(i));
      }

      public virtual void AddEdge(int i, int j)
      {
        INode<IntegerCoordinate> n1 = AddNode(i);
        INode<IntegerCoordinate> n2 = AddNode(j);
        myGraph.AddEdgeToNode(n1, n2);
      }
    }

    protected class CostContext : Context, IMorseEvaluatorCost<INode<IntegerCoordinate>>
    {
      private readonly Dictionary<INode<IntegerCoordinate>, double> myCosts;
      public double DefaultCost;

      public CostContext(IGraph<IntegerCoordinate> graph, Dictionary<INode<IntegerCoordinate>, double> costs)
        : base(graph)
      {
        myCosts = costs;
      }

      public void AddCost(int i, double v)
      {
        myCosts[AddNode(i)] = v;
      }

      public void AddCost(int i, double v, string bytes)
      {
        var vb = BitConverter.ToDouble(Convert.FromBase64String(bytes), 0);
        Assert.AreEqual(vb, v);
        AddCost(i, vb);
      }


      public override INode<IntegerCoordinate> AddNode(int i)
      {
        INode<IntegerCoordinate> node = base.AddNode(i);
        if (!myCosts.ContainsKey(node))
          myCosts[node] = DefaultCost;

        return node;
      }

      public double Cost(INode<IntegerCoordinate> t)
      {
        return myCosts[t];
      }
    }
  }
}