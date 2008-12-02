using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Logistics
{
  [SystemInfoComponent]
  public class Logistics2dFactory : DoubleParametersSystemInfoFactoryBase<Logistic2dParameters>
  {
    public Logistics2dFactory()
      : base(2, SystemType.Discrete,
             "Logistics2d")
    {
    }

    protected override ISystemInfo CreateInfo(Logistic2dParameters paramz)
    {
      return new Logistic2dSystemInfo();
    }
  }
}