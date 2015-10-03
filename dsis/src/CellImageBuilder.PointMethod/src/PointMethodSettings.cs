using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.PointMethod
{
  public class PointMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public readonly int[] Points;
    public readonly bool UseOverlapping;
    public readonly double Overlap;

    public PointMethodSettings(int[] points)
    {
      Points = points;
      UseOverlapping = false;
      Overlap = 0;
    }

    public PointMethodSettings(int[] points, double overlap)
    {
      Points = points;
      Overlap = overlap;
      UseOverlapping = false;
    }

    public string PresentableName
    {
      get { return "Point Method"; }
    }

    public ICellImageBuilder<TCell> Create<TCell>()       
      where TCell : IIntegerCoordinate
    {
      return new PointMethod<TCell>();
    }
  }
}