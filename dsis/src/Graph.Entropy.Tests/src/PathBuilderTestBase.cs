using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Path;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Tests
{
  public class PathBuilderTestBase : EntropyBlackboxTest
  {
    protected override Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> CreateEvaluator(string script,
                                                                                         TarjanGraph<IntegerCoordinate>
                                                                                           gr,
                                                                                         IGraphStrongComponents
                                                                                           <IntegerCoordinate> comps)
    {      
      PathBuilder bld = new PathBuilder(comps);
      bld.BuildPath();

      return Pair.Create(bld.Entropy(), (IEdgeInfo)bld);
    }

    private class PathBuilder : PathBuilder<IntegerCoordinate>, IEdgeInfo
    {
      public PathBuilder(IGraphStrongComponents<IntegerCoordinate> comps) : base(comps)
      {
      }

      public double Edge(IntegerCoordinate from, IntegerCoordinate to)
      {
        double v;
        NodePair<IntegerCoordinate> key = new NodePair<IntegerCoordinate>(from, to);
        if (myValues.Dictionary.TryGetValue(key, out v))
        {
          return v;
        }
        else
        {
          throw new KeyNotFoundException(string.Format("{0}->{1} not found", from.GetCoordinate(0), to.GetCoordinate(0)));
        }                
      }
    }
  }
}