using System.Collections.Generic;
using DSIS.SimpleRunner.Computation;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
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

      yield return new EntropyComputationData<object>
      {
        system = SystemInfoFactory.Duffing1_2x1_2Runge(),
        builder = ComputationDataBuilder.Box
      }.Enum().ForSteps(steps);
    }
  }
}