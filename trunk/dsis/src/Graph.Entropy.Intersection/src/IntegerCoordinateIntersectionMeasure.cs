using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Entropy.Intersection
{
  public class IntegerCoordinateIntersectionMeasure<Q> : IntersectionMeasure<Q>
    where Q : IIntegerCoordinate
  {
    public IntegerCoordinateIntersectionMeasure(ISystemInfo function, IGraph<Q> graph, ICellImageBuilderIntegerCoordinatesSettings settings) : base(function, graph, settings)
    {
    }

    protected override ICellImageBuilder<Q> CreateBuilder(ICellImageBuilderSettings settings)
    {
      return ((ICellImageBuilderIntegerCoordinatesSettings) settings).Create<Q>();
    }
  }
}