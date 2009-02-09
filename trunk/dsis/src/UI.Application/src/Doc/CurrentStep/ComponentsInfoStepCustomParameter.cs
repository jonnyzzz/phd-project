using System.Collections.Generic;
using System.Linq;
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

    private static IEnumerable<int> GetParettoCut(IEnumerable<int> infos)
    {
      long sum = infos.Aggregate(0, (x, y) => x + y);
      int v = 0;
      foreach (var info in infos)
      {
        if (v > sum * 0.8)
          yield break;

        v += info;
        yield return info;
      }
    }

    protected override string GetValue<T, Q>(T cs, Context ctx)
    {
      var cmp = Keys.GraphComponents<Q>().Get(ctx);
      var infos = (from c in cmp.Components orderby c.NodesCount select c.NodesCount).ToList();

      return cmp.ComponentCount + " ( " + GetParettoCut(infos).JoinString(c =>c + "", ", ") + " )";
    }
  }
}