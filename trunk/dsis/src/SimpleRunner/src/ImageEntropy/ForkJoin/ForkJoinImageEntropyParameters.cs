namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  public class ForkJoinImageEntropyParameters
  {
    public int SliceX { get; set; }
    public int SliceY { get; set; }

    public ForkJoinImageEntropyParameters()
    {
      SliceX = SliceY = 10;
    }

    public override string ToString()
    {
      return string.Format("Slice: {0}x{1}", SliceX, SliceY);
    }
  }
}
