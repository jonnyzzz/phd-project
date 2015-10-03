using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class SetStrangeEntropyParamsAction : ActionBase
  {
    private readonly StrangeEntropyEvaluatorParams myParams;

    public SetStrangeEntropyParamsAction(StrangeEntropyEvaluatorParams @params)
    {
      myParams = @params;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Keys.StrangeEntropyEvaluatorParams.Set(result, myParams);
    }
  }
}