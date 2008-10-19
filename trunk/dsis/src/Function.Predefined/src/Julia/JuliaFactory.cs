using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Julia
{
  [SystemInfoComponent]
  public class JuliaFactory : DoubleParametersSystemInfoFactoryBase<JuliaParameters>
  {
    public JuliaFactory()
      : base(2, SystemType.Descrete, "Julia")
    {
    }

    protected override ISystemInfo CreateInfo(JuliaParameters paramz)
    {
      return new JuliaFuctionSystemInfoDecorator();
    }
  }
}