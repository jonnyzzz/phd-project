using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisEntropyBuild : ThesisEntropyBuildBase<EntropyComputationData>
  {
    protected override IEnumerable<IEnumerable<EntropyComputationData>> GetSystemsToRun2()
    {
      var mode = new[]
                   {
                     EntropyComputationMode.JVR, 
                     EntropyComputationMode.SmartLoopsConst, 
                     EntropyComputationMode.SmartLoopsLinear, 
                     EntropyComputationMode.SmartLoopsSquare, 
                     EntropyComputationMode.Eigen,
                   };
      var steps = new[] {4, 6, 8, 10, 12, 14};

/*      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Henon1_4(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Ikeda(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);
      */
      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Duffing1_2x1_2Runge(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Delayed(2.27),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Ref9(.5),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.VanDerPolRunge(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);
    }
  }
}