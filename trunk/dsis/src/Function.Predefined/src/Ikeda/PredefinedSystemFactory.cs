using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined.Ikeda
{
  public abstract class PredefinedSystemFactory<TF> : ISystemInfoPredefinedFactory
    where TF : ISystemInfoFactory
  {
    [Autowire]
    protected TF Factory { get; set; }

    [Autowire]
    protected ISystemSpaceFactory InfoFactory { get; private set; }

    public string Name
    {
      get { return Factory.FactoryName; }
    }

    public abstract ISystemSpace Space { get; }

    public ISystemInfo Function
    {
      get { return Factory.Create(Parameters); }
    }

    protected abstract ISystemInfoParameters Parameters
    { 
      get;
    }
  }
}