using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Lorentz
{
  [SystemInfoComponent]
  public class LorentzSystemInfoFactory : DoubleParametersSystemInfoFactoryBase<LorentzParameters>
  {
    public LorentzSystemInfoFactory()
      : base(3, SystemType.Descrete, "Lorentz")
    {
    }

    protected override ISystemInfo CreateInfo(LorentzParameters paramz)
    {
      return new LorentzSystemInfo(paramz.Beta, paramz.Rho, paramz.Sigma);
    }
  }
}