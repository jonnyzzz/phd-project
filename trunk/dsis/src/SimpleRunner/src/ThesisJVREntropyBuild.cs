using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisJVREntropyBuild : ThesisJVREntropyBuildBase
  {
    protected override IEnumerable<IEnumerable<EntropyComputationData<object>>> GetSystemsToRun2()
    {
      var steps = new[] {4, 6, 8, 10, 12, 14};

      yield return new EntropyComputationData<object>
      {
        system = SystemInfoFactory.Henon1_4(),
        builder = ComputationDataBuilder.Box
      }.Enum().ForSteps(steps);

      yield return new EntropyComputationData<object>
      {
        system = SystemInfoFactory.Ikeda(),
        builder = ComputationDataBuilder.Box
      }.Enum().ForSteps(steps);
    }
  }
}