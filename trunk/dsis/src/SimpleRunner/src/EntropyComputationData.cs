using System.Collections.Generic;

namespace DSIS.SimpleRunner
{
  public class EntropyComputationData : ComputationData, ICloneable<EntropyComputationData>
  {
    public IEnumerable<EntropyComputationMode> EntropyMode { get; set; }

    public EntropyComputationData()
    {
    }

    protected EntropyComputationData(EntropyComputationData data) : base(data)
    {
      EntropyMode = new List<EntropyComputationMode>(data.EntropyMode).ToArray();
    }

    public EntropyComputationData Clone()
    {
      return new EntropyComputationData(this);
    }
  }
}