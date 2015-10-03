using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Linear
{
  [SystemInfoComponent]
  public class Linear2DFactory : DoubleParametersSystemInfoFactoryBase<Linear2dParameters>
  {
    public Linear2DFactory()
      : base(2, SystemType.Discrete, "Linear2D")
    {
    }

    protected override ISystemInfo CreateInfo(Linear2dParameters paramz)
    {
      return new Linear2DSystemInfo(paramz.A, paramz.B, paramz.C, paramz.D);
    }
  }
}