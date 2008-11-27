namespace DSIS.Core.Visualization
{
  public struct ImagePoint
  {
    public readonly double[] Point;

    public ImagePoint(params double[] point)
    {
      Point = point;
    }
  }
}