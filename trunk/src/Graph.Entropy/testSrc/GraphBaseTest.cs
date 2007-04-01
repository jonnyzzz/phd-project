using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;

namespace DSIS.Graph.Entropy
{
  public class GraphBaseTest
  {
    protected static T GetFirst<T>(IEnumerable<T> ts)
    {
      foreach (T t in ts){ return t; }
      return default(T);
    }

    protected delegate void BuildGraph(IGraph<IntegerCoordinate> graph);

    protected static void AddEdge(IGraph<IntegerCoordinate> graph,  int i, int j)
    {
      INode<IntegerCoordinate> n1 = graph.AddNode(new IntegerCoordinate(i));
      INode<IntegerCoordinate> n2 = graph.AddNode(new IntegerCoordinate(j));
      graph.AddEdgeToNode(n1, n2);
    }

    protected class MockCallback : IGraphWeightSearchCallback<IntegerCoordinate>
    {
      private readonly List<List<string>> myLoops = new List<List<string>>();

      void IGraphWeightSearchCallback<IntegerCoordinate>.OnLoopFound(IList<INode<IntegerCoordinate>> loop)
      {
        List<string> sloop = new List<string>();
        foreach (INode<IntegerCoordinate> node in loop)
        {
          sloop.Add(((IIntegerCoordinateDebug)node.Coordinate).Coordinate[0].ToString());
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
      MockSystemSpace mss = new MockSystemSpace(1, 0, 1, 1000);
      IntegerCoordinateSystem ics = new IntegerCoordinateSystem(mss);
      TarjanGraph<IntegerCoordinate> graph = new TarjanGraph<IntegerCoordinate>(ics);
      bg(graph);

      return graph;
    }

    protected static string ToString(INode<IntegerCoordinate> node)
    {
      return ((IIntegerCoordinateDebug) node.Coordinate).Coordinate[0].ToString();
    }

    internal static string ToString(NodePair<IntegerCoordinate> p)
    {
      return ToString(p.From) + "->" + ToString(p.To);      
    }
  }
}