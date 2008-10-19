using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Rossel
{
  [SystemInfoComponent]
  public class RosselFactory : DoubleParametersSystemInfoFactoryBase<RosslerParameters>
  {
    //todo: Provide continious system converter
    public RosselFactory()
      : base(3, SystemType.Continious, "Rossel")
    {
    }

    protected override ISystemInfo CreateInfo(RosslerParameters paramz)
    {
      return new RosslerSystemInfo(paramz.A, paramz.B, paramz.C);
    }
  }
}