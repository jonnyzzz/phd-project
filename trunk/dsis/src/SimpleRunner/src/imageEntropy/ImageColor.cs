namespace DSIS.SimpleRunner.imageEntropy
{
  public struct ImagePixel
  {
    public readonly int X;
    public readonly int Y;

    public ImagePixel(int x, int y)
    {
      X = x;
      Y = y;
    }
  }

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