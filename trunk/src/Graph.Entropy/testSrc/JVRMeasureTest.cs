using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.IntegerCoordinates.Impl;
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
      DoTest("fni", n(1, 2, 1/3.0), n(2, 1, 1/3.0), n(1,1,1/3.0));
    }


    protected static void DoTest(string script, params Node[] nodes)
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

      const double EPS = 1e-3;

      foreach (Node node in nodes)
      {
        IntegerCoordinate fromC = AddNode(g, node.From).Coordinate;
        IntegerCoordinate toC = AddNode(g, node.To).Coordinate;

        Assert.AreEqual(node.Weight, j.Edge(fromC, toC, EPS));
      }
    }

    protected static Node n(int f, int t, double w)
    {
      return new Node(f, t, w);
    }

    protected struct Node
    {
      public readonly int From;
      public readonly int To;
      public readonly double Weight;

      public Node(int from, int to, double weight)
      {
        From = from;
        To = to;
        Weight = weight;
      }
    }

    private class JVR : JVRMeasure<IntegerCoordinate>
    {
      public JVR(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components)
        : base(graph, components)
      {
      }

      public double Edge(IntegerCoordinate from, IntegerCoordinate to, double prec)
      {
        NodePair<IntegerCoordinate> ft = new NodePair<IntegerCoordinate>(from, to);
        NodePair<IntegerCoordinate> tf = new NodePair<IntegerCoordinate>(to, from);

        double ftV = myEdges[ft];
        double tfV = myBackEdges[tf];

        Assert.AreEqual(ftV, tfV, prec);

        return ftV;
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
              Iterate();
              break;
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