using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.Scheme.Objects.Systemx;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Function.Predefined.Ikeda
{
  public abstract class PredefinedSystemFactory<TF> : ISystemInfoPredefinedFactory
    where TF : ISystemInfoFactory
  {
    [Autowire]
    protected TF Factory { get; set; }

    [Autowire]
    protected ISystemSpaceFactory InfoFactory { get; private set; }

    [Autowire]
    protected RungeKuttSolverFactory RungeKuttFactory { get; private set; }

    protected virtual RungeKuttOptions RungeKuttOptions
    {
      get
      {
        return new RungeKuttOptions { dTime = 0.01, Steps = 100 };
      }
    }

    public string Name
    {
      get { return Factory.FactoryName; }
    }

    public abstract ISystemSpace Space { get; }

    public ISystemInfo Function
    {
      get
      {
        var systemInfo = Factory.Create(Parameters);
        if (systemInfo.Type == SystemType.Continious)
          return RungeKuttFactory.Create(systemInfo, RungeKuttOptions);

        return systemInfo;
      }
    }

    protected abstract ISystemInfoParameters Parameters { get; }
  }
}