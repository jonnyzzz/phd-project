using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class GraphBuildOneDiminsion : IGraphBuilder
  {
    public int Dimension
    {
      get { return 1; }
    }

    public IGraphBuilderProcessor Init(IIntegerCoordinateSystemInfo info)
    {
      return new Processor(info.CellSize[0]);
    }

    private class Processor : IGraphBuilderProcessor
    {
      private readonly double myEps;
      private readonly double[] tmp = new double[0];

      public Processor(double eps)
      {
        myEps = eps;
      }

      public void BuildGraph(PointGraph graph, double[] point)
      {
        double t = tmp[0] = point[0];
        PointGraphNode n1 = graph.CreateNodeCopy(tmp);
        PointGraphNode n2 = graph.CreateNodeCopy(t + myEps);
        graph.AddEdge(n1, n2);
      }
    }
  }
}