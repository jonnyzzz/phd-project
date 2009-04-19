using System.Collections.Generic;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class EntropyComputationData<T> : ComputationData, ICloneable<EntropyComputationData<T>>
  {
    public IEnumerable<T> EntropyMode { get; set; }

    public EntropyComputationData()
    {
    }

    protected EntropyComputationData(EntropyComputationData<T> data) : base(data)
    {
      EntropyMode = new List<T>(data.EntropyMode).ToArray();
    }

    EntropyComputationData<T> ICloneable<EntropyComputationData<T>>.Clone()
    {
      return new EntropyComputationData<T>(this);
    }

    public override void Serialize(Logger log)
    {
      base.Serialize(log);
      log.Write("Entropy: " + EntropyMode);
    }
  }
}