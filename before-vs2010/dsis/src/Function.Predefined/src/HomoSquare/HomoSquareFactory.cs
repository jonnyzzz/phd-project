using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.HomoSquare
{
  [SystemInfoComponent]
  public class HomoSquareFactory : DoubleParametersSystemInfoFactoryBase<HomoSquareOptions>
  {
    public HomoSquareFactory() : base(2, SystemType.Continious, "Homoclinic square")
    {
    }

    protected override ISystemInfo CreateInfo(HomoSquareOptions paramz)
    {
      return new HomoSquareSystemInfo(paramz.A);
    }
  }
}