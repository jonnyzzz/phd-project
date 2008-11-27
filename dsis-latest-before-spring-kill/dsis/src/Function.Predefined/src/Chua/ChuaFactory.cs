using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Chua
{
  [SystemInfoComponent]
  public class ChuaFactory : DoubleParametersSystemInfoFactoryBase<ChuaOptions>
  {
    public ChuaFactory()
      : base(
        3,
        SystemType.Continious,
        "Chua")
    {
    }

    protected override ISystemInfo CreateInfo(ChuaOptions paramz)
    {
      return new ChuaSystemInfo(paramz);
    }
  }
}