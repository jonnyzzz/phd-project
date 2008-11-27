using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Attributes;

namespace DSIS.Function.Predefined.Brusselator
{
  [SystemInfoComponent]
  public class BrusselatorFactory : DoubleParametersSystemInfoFactoryBase<BrusselatorOptions>
  {
    public BrusselatorFactory()
      : base(
        2,
        SystemType.Continious,
        "Brusselator")
    {
    }

    protected override ISystemInfo CreateInfo(BrusselatorOptions paramz)
    {
      return new BrusselatorSystemInfo(paramz);
    }
  }
}