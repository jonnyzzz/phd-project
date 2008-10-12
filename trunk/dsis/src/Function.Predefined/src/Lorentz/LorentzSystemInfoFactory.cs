using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Lorentz
{
  [UsedBySpring, ComponentCollection]
  public class LorentzSystemInfoFactory : DoubleParametersSystemInfoFactoryBase<LorentzParameters>
  {
    public LorentzSystemInfoFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(3, SystemType.Descrete, "Lorentz", 3, paramz => new LorentzSystemInfo(paramz[0], paramz[1], paramz[2]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(LorentzParameters paramz)
    {
      return new LorentzSystemInfo(paramz.Beta, paramz.Rho, paramz.Sigma);
    }
  }
}