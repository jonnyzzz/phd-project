using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils.Bean;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  [Serializable]
  public class AdaptiveMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly AdaptiveMethodSettings Default = new AdaptiveMethodSettings();

    [IncludeGenerate(Title = "Eps")]
    public double Eps { get; set; }
    [IncludeGenerate(Title = "Edges per cell limit")]
    public int EdgesPerCell { get; set; }
    [IncludeGenerate(Title = "Overlap factor")]
    public double OveplapFactor { get; set; }

    public AdaptiveMethodSettings() : this(0.5, 500, 0.2)
    {
    }

    public AdaptiveMethodSettings(double eps, int nodesPerCell, double overlapFactor)
    {
      Eps = eps;
      EdgesPerCell = nodesPerCell;
      OveplapFactor = overlapFactor;
    }

    public string PresentableName
    {
      get { return string.Format("Adaptive Method[eps={0},overlap={1},limit={2}]", Eps, OveplapFactor, EdgesPerCell) ; }
    }

    public ICellImageBuilder<TCell> Create<TCell>() 
      where TCell : IIntegerCoordinate
    {
      return new AdaptiveMethod<TCell>();
    }
  }
}