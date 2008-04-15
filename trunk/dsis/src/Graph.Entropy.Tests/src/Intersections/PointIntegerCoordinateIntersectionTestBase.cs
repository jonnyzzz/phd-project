using System;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Function.Mock;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Graph.Entropy.Intersection;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Tests.Intersections
{
  public abstract class PointIntegerCoordinateIntersectionTestBase : EntropyBlackboxTest
  {
    private ComputeOneFunction<double> myFun;
    private int myDiv;
    private bool myShouldWork;

    protected override Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> CreateEvaluator(
      string script,
      TarjanGraph<IntegerCoordinate> gr,
      IGraphStrongComponents <IntegerCoordinate> comps)
    {
      Measure ms = new Measure(myFun, gr, myDiv);
      GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> start = ms.Start();

      return Pair.Create<IGraphMeasure<IntegerCoordinate>,IEdgeInfo>(
        start, new GraphMeasureEdgeInfo<NodePair<IntegerCoordinate>>(start,
                                                                     delegate(IntegerCoordinate from,
                                                                              IntegerCoordinate to)
                                                                       {
                                                                         return new NodePair<IntegerCoordinate>(
                                                                           from, to); })
        );
    }



    protected void DoTest(ComputeOneFunction<double> fun, int sub, double entropy, params Node[] nodes)
    {
      try
      {
        myShouldWork = true;
        myFun = fun;
        myDiv = sub;

        DoTest(string.Empty, entropy, nodes);
      } finally
      {
        myShouldWork = false;
        myFun = null;
        myDiv = -1;
      }
    }


    protected override void DoTest(string script, double entropy, params Node[] nodes)
    {
      if (!myShouldWork)
        throw new Exception("This method cann't be called here. Use DoTest(ComputeOneFucntion<double>, ...) method");

      base.DoTest(script, entropy, nodes);
    }

    private class Measure : IntegerCoordinateIntersectionMeasure<IntegerCoordinate>
    {
      public Measure(ComputeOneFunction<double> function, IGraph<IntegerCoordinate> graph, int div) :
        base(new MockSystemInfo<double>(Proxy(function)
                                        , graph.CoordinateSystem.SystemSpace), graph, new PointMethodSettings(new int[]{div}))
      {
      }

      private static ComputeFunction<T> Proxy<T>(ComputeOneFunction<T> function)
      {
        return delegate(T[] ins, T[] outs) { outs[0] = function(ins[0]); };
      }

      public new GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> Start()
      {
        return (GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>>) base.Start();
      }
    }
  }
}