using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Henon
{
  [SystemInfoComponent]
  public class HenonDellnitzFactory : DoubleParametersSystemInfoFactoryBase<HenonDellnitzOptions>
  {
    public HenonDellnitzFactory()
      : base(2,SystemType.Descrete, "HenonDellnitz")
    {
    }

    protected override ISystemInfo CreateInfo(HenonDellnitzOptions paramz)
    {
      return new HenonDellnitzFunctionSystemInfoDecorator(paramz.A, paramz.B);
    }
  }
}