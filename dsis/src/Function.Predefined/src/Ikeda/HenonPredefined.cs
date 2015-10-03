using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class HenonPredefined : PredefinedSystemFactory<HenonFactory>
  {
    public HenonPredefined(HenonFactory factory, ISystemSpaceFactory infoFactory) : base(factory, infoFactory)
    {
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new HenonOptions(); }
    }
  }
}