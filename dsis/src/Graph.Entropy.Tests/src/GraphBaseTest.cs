using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  public class GraphBaseTest
  {
    [SetUp]
    public virtual void SetUp()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-us");
    }

    protected delegate void BuildGraph(IGraph<IntegerCoordinate> graph);

    protected static void AddEdge(IGraph<IntegerCoordinate> graph,  int i, int j)
    {
      var system = (IntegerCoordinateSystem)graph.CoordinateSystem;
      INode<IntegerCoordinate> n1 = AddNode(graph, system, i);
      INode<IntegerCoordinate> n2 = graph.AddNode(system.Create(j));
      graph.AddEdgeToNode(n1, n2);
    }

    protected static INode<IntegerCoordinate> AddNode(IGraph<IntegerCoordinate> graph, int id)
    {
      return AddNode(graph, (IIntegerCoordinateSystem<IntegerCoordinate>) graph.CoordinateSystem, id);
    }

    private static INode<IntegerCoordinate> AddNode(IGraph<IntegerCoordinate> graph, IIntegerCoordinateSystem<IntegerCoordinate> system, int i)
    {
      return graph.AddNode(system.Create(i));
    }

    protected class MockCallback : ILoopIteratorCallback<IntegerCoordinate>
    {
      private readonly List<List<string>> myLoops = new List<List<string>>();

      void ILoopIteratorCallback<IntegerCoordinate>.OnLoopFound(IEnumerable<INode<IntegerCoordinate>> loop, int length)
      {
        var sloop = new List<string>();
        foreach (INode<IntegerCoordinate> node in loop)
        {
          sloop.Add((node.Coordinate).GetCoordinate(0).ToString());
        }

        myLoops.Add(sloop);
      }

      public List<List<string>> Loops
      {
        get { return myLoops; }
      }
    }

    protected static TarjanGraph<IntegerCoordinate> DoBuildGraph(BuildGraph bg)
    {
      var mss = new MockSystemSpace(1, 0, 1, 100000);
      IIntegerCoordinateSystem<IntegerCoordinate> ics = IntegerCoordinateSystemFactory.Create(mss);
      var graph = new TarjanGraph<IntegerCoordinate>(ics);
      bg(graph);

      return graph;
    }

    protected static string ToString(IntegerCoordinate node)
    {
      return node.GetCoordinate(0).ToString();
    }

    internal static string ToString(NodePair<IntegerCoordinate> p)
    {
      return ToString(p.From) + "->" + ToString(p.To);      
    }
  }
}