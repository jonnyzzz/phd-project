using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Tests
{
  public class StrangeEntropyBlackboxTestBase : EntropyBlackboxTest
  {
    protected override Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> CreateEvaluator(
      string script,
      TarjanGraph<IntegerCoordinate> gr,
      IGraphStrongComponents<IntegerCoordinate> comps
      )
    {
      var ent = new StrangeEntropyEvaluator<IntegerCoordinate>();
      var @params = new StrangeEntropyEvaluatorParams(StrangeEvaluatorType.WeightSearch_1, StrangeEvaluatorStrategy.FIRST,
                                                                                EntropyLoopWeights.CONST);
      var measure = (GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>>) ent.Measure(gr, comps,@params);

      IGraphMeasure<IntegerCoordinate> m = measure;
      IEdgeInfo b = new EdgeInfoImpl(measure);
      return Pair.Of(m, b);
    }

    private class EdgeInfoImpl : IEdgeInfo
    {
      private readonly GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> myMeasure;

      public EdgeInfoImpl(GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> measure)
      {
        myMeasure = measure;
      }

      public double Edge(IntegerCoordinate from, IntegerCoordinate to)
      {
        double v;
        var key = new NodePair<IntegerCoordinate>(from, to);
        if (myMeasure.M.TryGetValue(key, out v))
          return v;
        throw new KeyNotFoundException(string.Format("{0}->{1} not found", from.GetCoordinate(0), to.GetCoordinate(0)));
      }
    }
  }
}