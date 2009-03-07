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
                       EntropyMode = new[]
                                       {
                                         EntropyComputationMode.JVR, 
                                         EntropyComputationMode.SmartLoopsConst, 
                                         EntropyComputationMode.SmartLoopsLinear, 
                                         EntropyComputationMode.SmartLoopsSquare, 
                                         EntropyComputationMode.Eigen,
                                       },
                       repeat = 4,
                       builder = ComputationDataBuilder.Point
                     }.Enum();//.ForSteps(4, 6, 8, 10).ForBuilders(ComputationDataBuilder.Point, ComputationDataBuilder.PointEx, ComputationDataBuilder.Box);
    }
  }
}