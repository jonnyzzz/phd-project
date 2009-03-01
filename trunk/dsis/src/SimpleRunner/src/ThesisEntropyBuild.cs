using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisEntropyBuild : ThesisEntropyBuildBase<EntropyComputationData>
  {
    protected override IEnumerable<IEnumerable<EntropyComputationData>> GetSystemsToRun2()
    {
      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Henon1_4(),
                       EntropyMode = new[] {EntropyComputationMode.JVR, EntropyComputationMode.SmartLoops},
                       repeat = 10,
                       builder = ComputationDataBuilder.Point
                     }.Enum();
    }
  }
}