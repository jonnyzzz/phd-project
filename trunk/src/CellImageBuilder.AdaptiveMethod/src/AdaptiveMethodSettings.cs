using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class AdaptiveMethodSettings : ICellImageBuilderSettings
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
  }
}