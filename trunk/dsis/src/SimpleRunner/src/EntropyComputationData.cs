using System.Collections.Generic;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class EntropyComputationData : ComputationData, ICloneable<EntropyComputationData>
  {
    public IEnumerable<EntropyComputationMode> EntropyMode { get; set; }

    public EntropyComputationData()
    {
    }

    private EntropyComputationData(EntropyComputationData data) : base(data)
    {
      EntropyMode = new List<EntropyComputationMode>(data.EntropyMode).ToArray();
    }

    EntropyComputationData ICloneable<EntropyComputationData>.Clone()
    {
      return new EntropyComputationData(this);
    }

    public override void Serialize(Logger log)
    {
      base.Serialize(log);
      log.Write("Entropy: " + EntropyMode);
    }
  }
}