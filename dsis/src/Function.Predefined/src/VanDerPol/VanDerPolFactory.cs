using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.VanDerPol
{
  [SystemInfoComponent]
  public class VanDerPolFactory : DoubleParametersSystemInfoFactoryBase<VanDerPolParameters>
  {
    public VanDerPolFactory()
      : base(2, SystemType.Continious, "Van-der-Pol")
    {
    }

    protected override ISystemInfo CreateInfo(VanDerPolParameters paramz)
    {
      return new VanDerPolSystemInfo(paramz.A);
    }
  }
}