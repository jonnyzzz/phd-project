using System.Collections.Generic;
using DSIS.Function.Predefined.Osipenko2015;
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
  }
}