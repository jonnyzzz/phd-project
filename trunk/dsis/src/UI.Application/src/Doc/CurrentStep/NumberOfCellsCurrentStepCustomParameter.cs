using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class NumberOfCellsCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    public string Name
    {
      get { return "Number of Cells"; }
    }

    public int Order
    {
      get { return (int)StepOrders.NumberOfCells; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo);
    }

    public string GetValue(Context ctx)
    {
      return ctx.CellEnumeratorCount().ToString();      
    }
  }
}