using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class AdaptiveMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly AdaptiveMethodSettings DEFAULT = new AdaptiveMethodSettings();

    internal readonly double Eps;
    internal readonly int EdgesPerCell;
    internal readonly double OveplapFactor;

    public AdaptiveMethodSettings() : this(0.5, 1 << 20, 0.2)
    {
    }

    public AdaptiveMethodSettings(double eps, int nodesPerCell, double overlapFactor)
    {
      Eps = eps;
      EdgesPerCell = nodesPerCell;
      OveplapFactor = overlapFactor;
    }

    public ICellImageBuilder<TCell> Create<TSys, TCell>() 
      where TSys : IIntegerCoordinateSystem<TCell> 
      where TCell : IIntegerCoordinate<TCell>
    {
      return new AdaptiveMethod<TSys, TCell>();
    }
  }
}