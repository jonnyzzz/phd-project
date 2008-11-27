using System.Collections.Generic;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class GraphBuildOneDiminsion : IGraphBuilder
  {
    public int Dimension
    {
      get { return 1; }
    }

    public IGraphBuilderProcessor Init(IIntegerCoordinateSystem info)
    {
      return new Processor(info.CellSize[0]);
    }

    private class Processor : IGraphBuilderProcessor
    {
      private readonly double myEps;

      public Processor(double eps)
      {
        myEps = eps;
      }

      public IEnumerable<PointGraphEdge> BuildGraph(PointGraph graph, double[] point)
      {
        double t = point[0];
        PointGraphNode n1 = graph.CreateNodeNoCopy(t);
        PointGraphNode n2 = graph.CreateNodeNoCopy(t + myEps);
        return new[] { graph.AddEdge(n1, n2) };
      }
    }
  }
}