using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring;

namespace DSIS.Function.Predefined.Linear
{
  [UsedBySpring]
  public class Linear2DFactory : DoubleParametersSystemInfoFactoryBase<Linear2dParameters>
  {
    public Linear2DFactory(DoubleArrayParser parser, SystemInfoFactory factory)
      : base(2, SystemType.Descrete, "Linear2D", 4, paramz => new Linear2DSystemInfo(paramz[0], paramz[1], paramz[2], paramz[3]), parser, factory)
    {
    }

    protected override ISystemInfo CreateInfo(Linear2dParameters paramz)
    {
      return new Linear2DSystemInfo(paramz.A, paramz.B, paramz.C, paramz.D);
    }
  }
}