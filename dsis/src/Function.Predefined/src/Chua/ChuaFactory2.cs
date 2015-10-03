using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Chua
{
  [SystemInfoComponent]
  public class ChuaFactory2 : DoubleParametersSystemInfoFactoryBase<ChuaOptions2>
  {
    public ChuaFactory2()
      : base(
        3,
        SystemType.Continious,
        "Chua2")
    {
    }

    protected override ISystemInfo CreateInfo(ChuaOptions2 paramz)
    {
      return new ChuaSystemInfo2(paramz);
    }
  }
}