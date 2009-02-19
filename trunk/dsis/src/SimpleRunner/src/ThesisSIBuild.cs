using System.Collections.Generic;
using DSIS.Scheme;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl.Actions.Console;

namespace DSIS.SimpleRunner
{
  public class ThesisSIBuild : SIBuild
  {
    protected override IEnumerable<ComputationData> GetSystemsToRun()
    {
/*
      yield return new ComputationData
                     {
                       builder = Builder.Box,
                       repeat = 10,
                       system = SystemInfoFactory.AlphaX(0.45)
                     };
      yield return new ComputationData
                     {
                       builder = Builder.Point,
                       repeat = 10,
                       system = SystemInfoFactory.AlphaX(0.45)
                     };
      yield return new ComputationData
                     {
                       builder = Builder.Adaptive,
                       repeat = 10,
                       system = SystemInfoFactory.AlphaX(0.45)
                     };
*/
      ////////////////////////////

      yield return new ComputationData
                     {
                       builder = Builder.Box,
                       repeat = 10,
                       system = SystemInfoFactory.Ref9()
                     };
    }

    protected override IActionEdgesBuilder CreateActionsAfterSI(IActionEdgesBuilder siConstructionAction, IAction system, bool isLast)
    {
      siConstructionAction.Edge(new DumpGraphInfoAction());
      siConstructionAction.Edge(new DumpGraphComponentsInfoAction());

      return base.CreateActionsAfterSI(siConstructionAction, system, isLast);
    }
  }
}