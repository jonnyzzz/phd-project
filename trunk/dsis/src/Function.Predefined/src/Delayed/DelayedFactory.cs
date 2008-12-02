using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Delayed
{
  [SystemInfoComponent]
  public class DelayedFactory : DoubleParametersSystemInfoFactoryBase<DelayedOptions>
  {
    public DelayedFactory()
      : base(2,
      SystemType.Discrete, 
      "Delayed")
    {

    }

    protected override ISystemInfo CreateInfo(DelayedOptions paramz)
    {
      return new DelayedFunctionSystemInfo(paramz.A);
    }
  }
}