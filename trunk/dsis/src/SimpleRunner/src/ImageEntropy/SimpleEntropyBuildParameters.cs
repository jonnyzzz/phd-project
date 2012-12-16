using DSIS.Utils;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public class SimpleEntropyBuildParameters : EntropyBuildParameters
  {
    public override EntropyBuildParameters Clone()
    {
      return new SimpleEntropyBuildParameters();
    }

    public override void Log(ILogger logger)
    {
      logger.Write("Mode=Simple");
    }

    public override string ToString()
    {
      return "Simple";
    }
  }
}