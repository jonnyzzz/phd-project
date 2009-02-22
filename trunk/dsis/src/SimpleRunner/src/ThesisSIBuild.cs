using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisSIBuild : SIBuild
  {
    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
//      yield return new ComputationData{system = SystemInfoFactory.AlphaX(0.45)}.Enum().ForAllBuilders();
//      yield return new ComputationData{system = SystemInfoFactory.Ref9()}.Enum().ForAllBuilders().ForSteps(6,8,10);
      var chua2 = new ComputationData{system = SystemInfoFactory.ChuaRunge2()}.Enum();
      yield return chua2.ForBuilders(ComputationDataBuilder.Point).ForSteps(8, 10, 12, 14, 16, 18);
      yield return chua2.ForBuilders(ComputationDataBuilder.Box).ForSteps(12, 14, 16, 18);
      yield return chua2.ForBuilders(ComputationDataBuilder.Adaptive).ForSteps(8, 10);
    }
  }
}