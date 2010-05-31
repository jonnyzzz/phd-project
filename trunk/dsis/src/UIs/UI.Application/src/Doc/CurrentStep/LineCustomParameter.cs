using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class LineCustomParameter : ICurrentStepCustomParameter
  {
    [Autowire]
    private IApplicationDocument Document { get; set; }
    
    public string Name
    {
      get { return "Segment"; }
    }

    public int Order
    { 
      get { return (int) StepOrders.Segment; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.LineKey);
    }

    public string GetValue(Context ctx)
    {
      return Keys.LineKey.Get(ctx).Count.ToString("N0");
    }
  }
}