using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
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

    protected static T GetFirst<T>(IEnumerable<T> ts)
    {
      foreach (T t in ts)
      {
        return t;
      }
      return default(T);
    }


    protected void DoTest(double value, BuildGraph bg)
    {
      var mss = new MockSystemSpace(1, 0, 1, 1000);
      IIntegerCoordinateSystem<IntegerCoordinate> ics = IntegerCoordinateSystemFactory.Create(mss);
      var graph = new TarjanGraph<IntegerCoordinate>(ics);
      var costs =
        new Dictionary<INode<IntegerCoordinate>, double>(EqualityComparerFactory<INode<IntegerCoordinate>>.GetComparer());

      var ctx = new CostContext(graph, costs);

      bg(ctx);

      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      Assert.IsTrue(components.ComponentCount > 0, "No components");
      Assert.IsTrue(components.ComponentCount == 1, "Only one component possible");

      MorseEvaluator<IntegerCoordinate> me = new ME(components, GetFirst(components.Components), costs);
      ComputationResult<IntegerCoordinate> compute = me.Compute(true);

      Assert.AreEqual(value, compute.Value, 1e-5);
    }

    #region Nested type: BuildGraph

    protected delegate void BuildGraph(CostContext ctx);

    #endregion

    #region Nested type: Context

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

    #endregion

    #region Nested type: CostContext

    protected class CostContext : Context
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


      public override INode<IntegerCoordinate> AddNode(int i)
      {
        INode<IntegerCoordinate> node = base.AddNode(i);
        if (!myCosts.ContainsKey(node))
          myCosts[node] = DefaultCost;

        return node;
      }
    }

    #endregion

    #region Nested type: ME

    private class ME : MorseEvaluator<IntegerCoordinate>
    {
      private readonly Dictionary<INode<IntegerCoordinate>, double> myCosts;

      public ME(IGraphStrongComponents<IntegerCoordinate> components, IStrongComponentInfo comp,
                Dictionary<INode<IntegerCoordinate>, double> costs) : base(new MorseEvaluatorOptions(), components, comp)
      {
        myCosts = costs;
      }

      protected override double Cost(INode<IntegerCoordinate> node)
      {
        return myCosts[node];
      }
    }

    #endregion
  }
}