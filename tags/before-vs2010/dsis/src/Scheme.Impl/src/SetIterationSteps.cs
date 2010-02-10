using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public class SetIterationSteps : ActionBase
  {
    private readonly IterationSteps mySteps;

    public SetIterationSteps(IterationSteps steps)
    {
      mySteps = steps;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Keys.Iterations.Set(result, mySteps);
    }
  }
}