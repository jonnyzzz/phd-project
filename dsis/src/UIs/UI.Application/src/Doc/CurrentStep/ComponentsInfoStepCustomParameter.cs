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
      return ctx.ContainsKey(Keys.GetGraphComponents<Q>());
    }

    protected override string GetValue<T, Q>(T cs, Context ctx)
    {
      var cmp = Keys.GetGraphComponents<Q>().Get(ctx);
      return string.Format("{0} ({1})", cmp.ComponentCount,
                           cmp.Components.JoinSomeOf(.8, x => x.NodesCount, x => x.NodesCount.ToString("N0")));
    }
  }
}