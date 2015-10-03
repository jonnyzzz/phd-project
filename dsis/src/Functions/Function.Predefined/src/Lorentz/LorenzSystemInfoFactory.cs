using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Lorentz
{
  [SystemInfoComponent]
  public class LorenzSystemInfoFactory : DoubleParametersSystemInfoFactoryBase<LorenzParameters>
  {
    public LorenzSystemInfoFactory()
      : base(3, SystemType.Continious, "Lorenz")
    {
    }

    protected override ISystemInfo CreateInfo(LorenzParameters paramz)
    {
      return new LorenzSystemInfo(paramz.Beta, paramz.Rho, paramz.Sigma);
    }
  }
}