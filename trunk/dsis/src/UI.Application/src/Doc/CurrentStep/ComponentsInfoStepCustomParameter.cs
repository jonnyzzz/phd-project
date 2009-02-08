using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class ComponentsInfoStepCustomParameter : IntegerCoordinateStepCustomParameterBase
  {
    public override string Name
    {
      get { return "Strong Components"; }
    }

    public override int Order
    {
      get { return (int) StepOrders.ComponentsInfo; }
    }

    protected override bool IsAvailable<T, Q>(T cs, Context ctx)
    {
      return ctx.ContainsKey(Keys.GraphComponents<Q>());
    }

    protected override string GetValue<T, Q>(T cs, Context ctx)
    {
      var cmp = Keys.GraphComponents<Q>().Get(ctx);
      return cmp.ComponentCount + " ( " + cmp.Components.JoinString(c =>c.NodesCount + "", ", ") + " )";
    }
  }
}