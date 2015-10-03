using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class FunctionCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    [Autowire]
    private IApplicationDocument Document { get; set; }

    public string Name
    {
      get { return "System Name"; }
    }

    public int Order
    {
      get { return (int)StepOrders.SystemName; }
    }

    public bool IsAvailable(Context ctx)
    {
      return true;
    }

    public string GetValue(Context ctx)
    {
      return Document.System.PresentableName;
    }
  }
}