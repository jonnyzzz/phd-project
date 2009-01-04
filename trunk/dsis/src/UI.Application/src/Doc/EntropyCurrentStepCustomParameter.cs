using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class EntropyCurrentStepCustomParameter : ICurrentStepCustomParameter
  {
    public string Name
    {
      get { return "Entropy"; }
    }

    public bool IsAvailable(Context ctx)
    {
      return ctx.ContainsKey(Keys.GraphEntropyKey);
    }

    public string GetValue(Context ctx)
    {
      return Keys.GraphEntropyKey.Get(ctx).GetEntropy().ToString("E10");
    }
  }
}