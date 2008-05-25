using System.Collections.Generic;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.UI.FunctionDialog
{
  public class SelectPredefinedContiniousMethodPage : ListSelectorBase<IContiniousFunctionSolverFactory>
  {
    public SelectPredefinedContiniousMethodPage(IEnumerable<IContiniousFunctionSolverFactory> factories) : base(factories)
    {
    }

    protected override string FactoryName(IContiniousFunctionSolverFactory factory)
    {
      return factory.MethodName;
    }
  }
}