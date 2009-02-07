using DSIS.Core.System;
using DSIS.Function.Predefined.Henon;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class HenonPredefined : PredefinedSystemFactory<HenonFactory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new HenonOptions(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSymmetricalSpace(2, 10, 2); }
    }
  }
}