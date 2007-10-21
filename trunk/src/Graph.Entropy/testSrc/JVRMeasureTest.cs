using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class JVRMeasureTest : GraphBaseTest
  {
    [Test]
    public void Test_F_One()
    {
      DoTest("f", n(1, 1, 1));
    }

    [Test]
    public void Test_F_Two()
    {
      DoTest("f", n(1, 1, 1), n(2, 2, 1));
    }

    [Test]
    public void Test_F_Two2()
    {
      DoTest("f", n(1, 2, 1), n(2, 1, 1));
    }

    [Test]
    public void Test_FI_One()
    {
      DoTest("fni", n(1, 1, 1));
    }

    [Test]
    public void Test_FI_Two()
    {
      DoTest("fni", n(1, 1, 1/2.0), n(2, 2, 1/2.0));
    }

    [Test]
    public void Test_FI_Two2()
    {
      DoTest("fni", n(1, 2, 1/2.0), n(2, 1, 1/2.0));
    }

    [Test]
    public void Test_FI_Three()
    {
      DoTest("fni", n(1, 2, 1/3.0), n(2, 1, 1/3.0), n(1, 1, 1/3.0));
    }

    [Test]
    public void Test_Ampi()
    {                                           
       DoTest("fni", 0.2215, n(1, 2), n(2, 3), n(3, 5), n(5, 1), n(3, 8),
              n(8, 7), n(7, 6), n(6, 2));                                                                                        
    }

    [Test]
    public void Test_BigFull()
    {
      List<Node> ns = new List<Node>();
      const int N = 10;
      for(int i=0; i<N; i++)
      {
        for(int j=0; j<N; j++)
        {          
          ns.Add(n(i,j));
        }
      }

      DoTest("fni", 3.3219280948873489, ns.ToArray());
    }

    private const double EPS = 1e-3;

    protected static JVR DoTest(string script, double entropy, params Node[] nodes)
    {
      JVR j = DoTest(script, nodes);

      EntropyListener<IntegerCoordinate> l = new EntropyListener<IntegerCoordinate>();
      j.CreateEvaluator().ComputeEntropy(l);

      Console.Out.WriteLine("l.Result = {0}", l.Result);
      Assert.AreEqual(entropy, l.Result, EPS);

      return j;
    }

    private class EntropyListener<T> : IEntropyListener<T>
      where T : ICellCoordinate<T>
    {
      private double? myResult;

      public void OnResult(double result, IDictionary<T, double> measure)
      {
        myResult = result;
      }

      public double Result
      {
        get
        {
          Assert.IsNotNull(myResult);
          return myResult.Value;
        }
      }
    }

    protected static JVR DoTest(string script, params Node[] nodes)
    {
      TarjanGraph<IntegerCoordinate> g = DoBuildGraph(delegate(IGraph<IntegerCoordinate> graph)
                                                        {
                                                          foreach (Node node in nodes)
                                                          {
                                                            AddEdge(graph, node.From, node.To);
                                                          }
                                                        });
      IGraphStrongComponents<IntegerCoordinate> c = g.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      JVR j = new JVR(g, c);

      j.Script(script);

      Dictionary<IntegerCoordinate, double> mi =
        new Dictionary<IntegerCoordinate, double>(EqualityComparerFactory<IntegerCoordinate>.GetComparer());

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
            Assert.AreEqual(w.Value, edge, EPS);
        }
      }
      finally
      {        
        foreach (Node node in nodes)
        {
          IntegerCoordinate fromC = AddNode(g, node.From).Coordinate;
          IntegerCoordinate toC = AddNode(g, node.To).Coordinate;

          Console.Out.WriteLine("{0}->{1} {2}", fromC, toC, j.Edge(fromC, toC));
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
      finally
      {
        Console.Out.WriteLine();
        foreach (KeyValuePair<IntegerCoordinate, double> pair in mi)
        {
          Console.Out.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
        Console.Out.WriteLine();
      }

      return j;
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
    }

    protected class JVR : JVRMeasure<IntegerCoordinate>
    {
      public JVR(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components)
        : base(graph, components)
      {
      }

      public double Edge(IntegerCoordinate from, IntegerCoordinate to)
      {
        JVRPair<IntegerCoordinate> ft = new JVRPair<IntegerCoordinate>(from, to);

        return myHashHolder.GetItem(ft);
      }

      public void Script(IEnumerable<char> s)
      {
        foreach (char c in s)
        {
          switch (c)
          {
            case 'f':
              FillGraph();
              break;
            case 'i':
              Iterate(EPS / 1000);
              return;
            case 'n':
              Norm();
              break;
            default:
              Assert.Fail(string.Format("Unexpected action: {0} in {1}", c, s));
              break;
          }
        }
      }
    }
  }
}