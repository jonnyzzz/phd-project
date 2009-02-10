using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class SubdivisionCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    public string Name
    {
      get { return "Subdivison"; }
    }

    public int Order
    {
      get { return (int)StepOrders.Subdivision; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo);
    }

    public string GetValue(Context ctx)
    {
      return ctx.Get(Keys.IntegerCoordinateSystemInfo).Subdivision.JoinString(l=>l.ToString("N0"), "x");
    }
  }
}