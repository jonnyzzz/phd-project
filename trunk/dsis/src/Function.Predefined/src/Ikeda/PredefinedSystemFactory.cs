using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  public abstract class PredefinedSystemFactory<TF> : ISystemInfoPredefinedFactory
    where TF : ISystemInfoFactory
  {
    private readonly TF myFactory;
    private readonly ISystemSpaceFactory myInfoFactory;

    protected PredefinedSystemFactory(TF factory, ISystemSpaceFactory infoFactory)
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
      get { return myFactory.Create(Parameters); }
    }

    protected abstract ISystemInfoParameters Parameters
    { 
      get;
    }
  }
}