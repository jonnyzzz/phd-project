using System.Collections.Generic;

namespace DSIS.SimpleRunner
{
  public class EntropyComputationData : ComputationData, IClonable<EntropyComputationData>
  {
    public IEnumerable<EntropyComputationMode> EntropyMode { get; set; }

    public EntropyComputationData Clone()
    {
      return new EntropyComputationData
               {
                 system = system,
                 repeat = repeat,
                 builder = builder,
                 EntropyMode = new List<EntropyComputationMode>(EntropyMode)
               };
    }
  }
}