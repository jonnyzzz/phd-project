using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class EntropyCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    public string Name
    {
      get { return "Entropy"; }
    }

    public int Order
    {
      get { return (int)StepOrders.EntropyOrder; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.GraphEntropyKey);
    }

    public string GetValue(Context ctx)
    {
      return Keys.GraphEntropyKey.Get(ctx).GetEntropy().ToString("E");
    }
  }
}