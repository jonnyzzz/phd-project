using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.IntegerCoordinates;
using DSIS.LineIterator;

namespace DSIS.Scheme.Impl
{
  public static class Keys
  {
    public static readonly Key<ISystemSpace> SystemSpaceKey = new Key<ISystemSpace>("SystemSpace");
    public static readonly Key<long[]> SubdivisionKey = new Key<long[]>("Subdivision");

    public static readonly Key<IIntegerCoordinateSystem> IntegerCoordinateSystemInfo =
      new Key<IIntegerCoordinateSystem>("Info");

    public static readonly Key<ISystemInfo> SystemInfoKey = new Key<ISystemInfo>("Function");

    public static readonly Key<ICellImageBuilderIntegerCoordinatesSettings> CellImageBuilderKey =
      new Key<ICellImageBuilderIntegerCoordinatesSettings>("Builder");

    public static Key<ICellCoordinateCollection<Q>> CellsEnumerationKey<Q>() where Q : ICellCoordinate
    {
      return new Key<ICellCoordinateCollection<Q>>("Cells");
    }

    public static Key<IGraph<Q>> Graph<Q>() where Q : ICellCoordinate
    {
      return new Key<IGraph<Q>>("graph");
    }

    public static Key<IGraphStrongComponents<Q>> GraphComponents<Q>() where Q : ICellCoordinate
    {
      return new Key<IGraphStrongComponents<Q>>("comps");
    }

    public static readonly Key<StrangeEntropyEvaluatorParams> StrangeEntropyEvaluatorParams = new Key<StrangeEntropyEvaluatorParams>("");
    
    public static Key<IGraphMeasure<T>> GraphMeasure<T>() where T : ICellCoordinate
    {
      return new Key<IGraphMeasure<T>>("measure");
    }

    public static readonly Key<IGraphEntropy> GraphEntropyKey = new Key<IGraphEntropy>("measure");

    public static readonly Key<ILine> LineKey = new Key<ILine>("Line");
  }
}