using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.HomoLinear
{
  [SystemInfoComponent]
  public class HomoLinearSystemInfoFactory : DoubleParametersSystemInfoFactoryBase<HomoLinearOptions>
  {
    public HomoLinearSystemInfoFactory() : base(2, SystemType.Continious, "Homoiclinic linear")
    {
    }

    protected override ISystemInfo CreateInfo(HomoLinearOptions paramz)
    {
      return new HomoLinearSystemInfo(paramz.A);
    }
  }
}