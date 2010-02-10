using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class CellSizeCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    public string Name
    {
      get { return "Cell Size"; }
    }

    public int Order
    {
      get { return (int)StepOrders.CellSize; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo);
    }

    public string GetValue(Context ctx)
    {
      return ctx.Get(Keys.IntegerCoordinateSystemInfo).CellSize.JoinString(d => d.ToString("E"), ", ");
    }
  }
}