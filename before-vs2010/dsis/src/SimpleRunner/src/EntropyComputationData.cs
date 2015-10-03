namespace DSIS.SimpleRunner
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