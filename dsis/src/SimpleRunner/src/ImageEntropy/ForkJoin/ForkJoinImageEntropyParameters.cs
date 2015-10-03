using DSIS.Utils;

namespace DSIS.SimpleRunner.ImageEntropy.ForkJoin
{
  public class ForkJoinImageEntropyParameters : EntropyBuildParameters
  {
    public int SliceX { get; set; }
    public int SliceY { get; set; }
    public int Overlap { get; set; }

    public ForkJoinImageEntropyParameters()
    {
      SliceX = SliceY = 10;
      Overlap = 1;
    }

    public override string ToString()
    {
      return string.Format("Slice: {0}x{1}", SliceX, SliceY);
    }

    public override void Log(ILogger logger)
    {
      logger.Write("Mode=ForkJoin");
      logger.Write("SliceX={0}", SliceX);
      logger.Write("SliceY={0}", SliceY);
      logger.Write("Overlap={0}", Overlap);
    }

    public override EntropyBuildParameters Clone()
    {
      return new ForkJoinImageEntropyParameters
        {
          SliceX = SliceX,
          SliceY = SliceY,
          Overlap = Overlap
        };
    }
  }
}
