using DSIS.Core.System.Impl;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class IkedaPredefined : PredefinedSystemFactory<IkedaFactory>
  {
    public IkedaPredefined(IkedaFactory factory, ISystemSpaceFactory infoFactory) : base(factory, infoFactory)
    {
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new IkedaParameters(); }
    }
  }
}