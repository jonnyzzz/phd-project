using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Solvers
{
  public class ContiniousFunctionSolverBase : IContiniousFunctionSolverFactory
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
  }
}