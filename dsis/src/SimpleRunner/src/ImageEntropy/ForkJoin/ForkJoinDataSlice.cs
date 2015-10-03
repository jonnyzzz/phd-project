namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  public struct ForkJoinDataSlice
  {
    public readonly ImagePixel Coord;
    public readonly ImageEntropyData Data;
    public readonly string SliceName;

    public ForkJoinDataSlice(ImagePixel c, ImageEntropyData data)
    {
      Coord = c;
      Data = data;
      SliceName = Coord.ToString();
    }
  }
}