using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.UI.FunctionDialog
{
  public class ContiniousFunctionSolverWrapper : IOptionsBasedFactory<IContiniousSolverParameters, ISystemInfo>
  {
    private readonly ISystemInfo mySystemInfo;
    private readonly IContiniousFunctionSolverFactory myFactory;

    public ContiniousFunctionSolverWrapper(ISystemInfo systemInfo, IContiniousFunctionSolverFactory factory)
    {
      mySystemInfo = systemInfo;
      myFactory = factory;
    }

    public string FactoryName
    {
      get { return myFactory.MethodName; }
    }

    public IContiniousSolverParameters CreateOptions()
    {
      return myFactory.CreateOptions();
    }

    public ISystemInfo Create(IContiniousSolverParameters options)
    {
      return myFactory.Create(mySystemInfo, options);
    }
  }
}