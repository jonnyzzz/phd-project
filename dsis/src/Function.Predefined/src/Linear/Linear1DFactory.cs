using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Linear
{
  [SystemInfoComponent]
  public class Linear1DFactory : DoubleParametersSystemInfoFactoryBase<Linear1dParameters>
  {
    public Linear1DFactory()
      : base(1,SystemType.Discrete, "Linear1D")
    {
    }

    protected override ISystemInfo CreateInfo(Linear1dParameters paramz)
    {
      return new Linear1DSystemInfo(paramz.A, paramz.B);
    }
  }
}