using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Solvers
{
  public abstract class ContiniousFunctionSolverBase : IContiniousFunctionSolverFactory
  {
    private readonly string myTitle;

    protected ContiniousFunctionSolverBase(string title)
    {
      myTitle = title;
    }

    public string MethodName
    {
      get { return myTitle; }
    }

    public abstract ISystemInfo Create(ISystemInfo system, IContiniousSolverParameters parameters);

    public abstract Type OptionsObjectType { get; }
  }
}