using System.Collections.Generic;

namespace DSIS.SimpleRunner
{
  public class EntropyComputationData : ComputationData
  {
    public IEnumerable<EntropyComputationMode> EntropyMode { get; set; }
    
  }
}