using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public interface IGraphBuilder
  {
    int Dimension { get; }
    IGraphBuilderProcessor Init(IIntegerCoordinateSystemInfo info);
  }
  
  public interface IGraphBuilderProcessor
  {
    void BuildGraph(PointGraph graph, double[] point);
  }
}