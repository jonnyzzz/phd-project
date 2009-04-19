using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisJVREntropyBuild : ThesisJVREntropyBuildBase
  {
    protected override IEnumerable<IEnumerable<EntropyComputationData<JVRExitCondition>>> GetSystemsToRun2()
    {
      var mode = Enum.GetValues(typeof(JVRExitCondition)).Cast<JVRExitCondition>().ToArray();

      yield return new EntropyComputationData<JVRExitCondition>
      {
        system = SystemInfoFactory.Henon1_4(),
        EntropyMode = mode,
        builder = ComputationDataBuilder.Box
      }.Enum().ForSteps(4, 6, 8, 10, 12, 14);

      yield return new EntropyComputationData<JVRExitCondition>
      {
        system = SystemInfoFactory.Ikeda(),
        EntropyMode = mode,
        builder = ComputationDataBuilder.Box
      }.Enum().ForSteps(4, 6, 8, 10, 12, 14);
    }
  }
}