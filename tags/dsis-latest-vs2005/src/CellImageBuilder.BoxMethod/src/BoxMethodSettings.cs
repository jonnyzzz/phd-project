using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.BoxMethod
{
  public sealed class BoxMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly BoxMethodSettings Default = new BoxMethodSettings(0.1);
    private readonly double myEps;

    public BoxMethodSettings(double eps)
    {
      myEps = eps;
    }

    /// <summary>
    /// Relative epsilone to be added as border to the build rectangle.
    /// Eps = 1 means 1 cell size on the corresponding coordinate
    /// </summary>
    public double Eps
    {
      get { return myEps; }
    }

    public string PresentableName
    {
      get { return "Box Method"; }
    }


    public ICellImageBuilder<TCell> Create<TCell>()
      where TCell : IIntegerCoordinate
    {
      return new BoxMethod<TCell>();
    }
  }
}