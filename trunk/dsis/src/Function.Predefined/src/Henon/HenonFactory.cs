using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Henon
{
  [SystemInfoComponent]
  public class HenonFactory : DoubleParametersSystemInfoFactoryBase<HenonOptions>
  {
    public HenonFactory()
      : base(2,SystemType.Descrete, "Henon")
    {
    }

    protected override ISystemInfo CreateInfo(HenonOptions paramz)
    {
      return new HenonFunctionSystemInfoDecorator(paramz.A);
    }
  }
}