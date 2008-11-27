using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class IkedaFactory : DoubleParametersSystemInfoFactoryBase<IkedaParameters>
  {
    public IkedaFactory()
      : base(2,SystemType.Descrete, "Ikeda")
    {
    }

    protected override ISystemInfo CreateInfo(IkedaParameters paramz)
    {
      return new IkedaFunctionSystemInfoDecorator();
    }
  }
}