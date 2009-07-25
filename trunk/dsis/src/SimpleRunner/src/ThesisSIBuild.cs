using System.Collections.Generic;
using DSIS.Utils;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public class ThesisSIBuild : SIBuild
  {
    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      yield return
        new ComputationData { system = SystemInfoFactory.Ref9(.5) }.Enum().ForBuilders(ComputationDataBuilder.Point, ComputationDataBuilder.Adaptive).ForSteps(10);
    }

    /*protected override; IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      yield return GetSystemsToRun3().ForAllBuilders().ForSteps(2,2,2, 4, 6, 8, 10, 12, 14, 16).ForAllCoordinateSystems();
    }

    private static IEnumerable<ComputationData> GetSystemsToRun3()
    {
      yield return new ComputationData {system = SystemInfoFactory.AlphaX(0.45)};
      yield return new ComputationData {system = SystemInfoFactory.Ref9(0.5)};
      yield return new ComputationData {system = SystemInfoFactory.ChuaRunge2()};
      yield return new ComputationData {system = SystemInfoFactory.Delayed(2.27)};
      yield return new ComputationData {system = SystemInfoFactory.Delayed(2.21)};
      yield return new ComputationData {system = SystemInfoFactory.VanDerPolRunge()};      
      yield return new ComputationData {system = SystemInfoFactory.Duffing1_3x1_3Runge()};
      yield return new ComputationData {system = SystemInfoFactory.FoodChainDanny()};
      yield return new ComputationData {system = SystemInfoFactory.Henon1_4()};
      yield return new ComputationData {system = SystemInfoFactory.Ikeda()};
    }*/
  }
}