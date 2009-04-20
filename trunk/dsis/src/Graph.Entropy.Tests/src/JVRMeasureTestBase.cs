using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  public abstract class JVRMeasureTestBase : EntropyBlackboxTest
  {
    protected override Pair<IGraphMeasure<IntegerCoordinate>,IEdgeInfo> CreateEvaluator(string script, TarjanGraph<IntegerCoordinate> gr,
                                                               IGraphStrongComponents<IntegerCoordinate> comps)
    {
      JVR jvr = new JVR(gr, comps, EPS/1000);
      jvr.Script(script);
      IGraphMeasure<IntegerCoordinate> evaluator = jvr.CreateEvaluator();
      IEdgeInfo info = jvr;
      return Pair.Create(evaluator, info);
    }

    protected class JVR : JVRMeasure<IntegerCoordinate>, IEdgeInfo
    {
      private readonly double myEps;
      private readonly IGraph<IntegerCoordinate> myGraph;

      public JVR(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components, double eps)
        : base(graph, components, new JVRMeasureOptions{IncludeSelfEdge = false})
      {
        myGraph = graph;
        myEps = eps;
      }

      public double Edge(IntegerCoordinate from, IntegerCoordinate to)
      {
        var ft = new JVRPair<IntegerCoordinate>(from, to);
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
              Iterate(myEps);
              return;
            case 'n':
              Norm();
              break;
            case 'v':
              Assert.AreEqual(myGraph.NodesCount, QueueSize);
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