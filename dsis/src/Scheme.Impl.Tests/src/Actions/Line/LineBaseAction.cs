using System.Collections.Generic;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Line
{
  public abstract class LineBaseAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {      
      return CheckContext(ctx, Create(Keys.LineKey));
    }

    protected sealed override void Apply(Context ctx, Context result)
    {
      Apply(Keys.LineKey.Get(ctx), ctx, result);
    }

    protected abstract void Apply(ILine line, Context ctx, Context result);
  }
}