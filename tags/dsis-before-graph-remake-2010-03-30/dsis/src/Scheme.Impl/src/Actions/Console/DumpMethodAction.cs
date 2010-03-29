using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpMethodAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(Keys.CellImageBuilderKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      var sets = Keys.CellImageBuilderKey.Get(ctx);
      Logger.Instance(ctx).Write("Method: {0}", sets.PresentableName);
    }
  }
}