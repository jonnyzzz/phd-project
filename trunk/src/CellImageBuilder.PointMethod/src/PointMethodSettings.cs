using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilders.PointMethod
{
  public class PointMethodSettings : ICellImageBuilderSettings
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
  }
}