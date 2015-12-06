using System.Collections.Generic;
using DSIS.Function.Predefined.Osipenko2015;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions;
using DSIS.SimpleRunner.Builder;
using DSIS.SimpleRunner.Computation;
using DSIS.SimpleRunner.Data;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.SimpleRunner.Entropy
{
  [ComponentImplementation]
  public class Osipenko2015Build : SIBuild<ComputationData>
  {
    [Autowire] public Osipenko2015Predefined SystemFactory { get; set; }
    [Autowire] public DetMorse DetMorse { get; set; }

    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      yield return new[]
      {
        new ComputationData
        {
          builder = ComputationDataBuilder.Box,
          CoordinateSystemType = CoordinateSystemType.Implemented,
          repeat = 15,
          system = new SystemInfoAction(SystemFactory.Function, SystemFactory.Space)
        }
      };
    }

    protected override IActionEdgesBuilder CreateActionsAfterSI(AfterSIParams<ComputationData> afterSIParams)
    {
      DetMorse.BuildJVRCall(afterSIParams, 1e-5);

      return base.CreateActionsAfterSI(afterSIParams);
    }
  }
}
