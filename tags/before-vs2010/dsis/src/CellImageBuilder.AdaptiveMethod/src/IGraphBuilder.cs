using System.Collections.Generic;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public interface IGraphBuilder
  {
    int Dimension { get; }
    IGraphBuilderProcessor Init(IIntegerCoordinateSystem info);
  }
  
  public interface IGraphBuilderProcessor
  {
    IEnumerable<PointGraphEdge> BuildGraph(PointGraph graph, double[] point);
  }
}