using System;
using System.Collections.Generic;
using DSIS.SimpleRunner.Computation;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Entropy
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
      var span = TimeSpan.FromMinutes(30);

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
                       ExecutionTimeout = span,
                       system = SystemInfoFactory.Duffing1_2x1_2Runge(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       ExecutionTimeout = span,
                       system = SystemInfoFactory.Delayed(2.27),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       ExecutionTimeout = span,
                       system = SystemInfoFactory.Ref9(.5),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);

      yield return new EntropyComputationData
                     {
                       ExecutionTimeout = span,
                       system = SystemInfoFactory.VanDerPolRunge(),
                       EntropyMode = mode,
                       builder = ComputationDataBuilder.Box
                     }.Enum().ForSteps(steps);
    }
  }
}