using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  [SystemInfoComponent]
  public class IkedaPredefined : ISystemInfoPredefinedFactory
  {
    private readonly IkedaFactory myFactory;
    private readonly ISystemSpaceFactory myInfoFactory;

    public IkedaPredefined(IkedaFactory factory, ISystemSpaceFactory infoFactory)
    {
      myFactory = factory;
      myInfoFactory = infoFactory;
    }

    public string Name
    {
      get { return myFactory.FactoryName; }
    }

    public ISystemSpace Space
    {
      get { return myInfoFactory.CreateSymmetricalSpace(2, 10, 2); }
    }

    public ISystemInfo Function
    {
      get { return myFactory.Create(new IkedaParameters()); }
    }
  }
}