namespace DSIS.SimpleRunner.imageEntropy
{
  public struct ImageColor
  {
    public readonly int X;
    public readonly int Y;
    public readonly double Color;

    public ImageColor(int x, int y, double color)
    {
      X = x;
      Y = y;
      Color = color;
    }
  }
}