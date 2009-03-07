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

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Henon1_4(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(4, 6, 8, 10, 12, 14);

      yield return new EntropyComputationData
                     {
                       system = SystemInfoFactory.Ikeda(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(4, 6, 8, 10, 12, 14);
    }
  }
}