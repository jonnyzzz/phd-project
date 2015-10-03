using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class IkedaPredefined : PredefinedSystemFactory<IkedaFactory>
  {
    protected override ISystemInfoParameters Parameters
    {
      get { return new IkedaParameters(); }
    }

    public override ISystemSpace Space
    {
      get { return InfoFactory.CreateSymmetricalSpace(2, 10, 2); }
    }
  }
}