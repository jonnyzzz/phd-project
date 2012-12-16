using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public abstract class EntropyBuildParameters : ICloneable<EntropyBuildParameters>, ILoggable
  {
    public abstract EntropyBuildParameters Clone();
    public abstract override string ToString();
    public abstract void Log(ILogger logger);
  }
}