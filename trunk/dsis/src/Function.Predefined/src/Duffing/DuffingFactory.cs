using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Duffing
{
  [SystemInfoComponent]
  public class DuffingFactory : DoubleParametersSystemInfoFactoryBase<DuffingOptions>
  {
    public DuffingFactory()
      : base(2, SystemType.Descrete, "Duffing")
    {
    }

    protected override ISystemInfo CreateInfo(DuffingOptions paramz)
    {
      return new DuffingSystemInfo(paramz.Alpha, paramz.Beta, paramz.K);
    }
  }
}