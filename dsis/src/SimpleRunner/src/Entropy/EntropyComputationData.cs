using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
{
  public class EntropyComputationData : EntropyComputationData<EntropyComputationMode>, ICloneable<EntropyComputationData>
  {
    public EntropyComputationData()
    {
    }

    protected EntropyComputationData(EntropyComputationData<EntropyComputationMode> data) : base(data)
    {
    }

    public EntropyComputationData Clone()
    {
      return new EntropyComputationData(this);
    }
  }
}