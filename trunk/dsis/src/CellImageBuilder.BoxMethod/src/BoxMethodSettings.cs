using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.BoxMethod
{
  [Serializable]
  public class BoxMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly BoxMethodSettings Default = new BoxMethodSettings(0.1);

    [Used]
    public BoxMethodSettings()
    {
    }

    public BoxMethodSettings(double eps)
    {
      Eps = eps;
    }

    /// <summary>
    /// Relative epsilone to be added as border to the build rectangle.
    /// Eps = 1 means 1 cell size on the corresponding coordinate
    /// </summary>
    public double Eps { get; set;}

    public string PresentableName
    {
      get { return string.Format("Box Method[eps={0}]", Eps); }
    }

    public ICellImageBuilder<TCell> Create<TCell>()
      where TCell : IIntegerCoordinate
    {
      return new BoxMethod<TCell>();
    }
  }
}