using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class IterationStepsPrefixWorkingFolderAction : PrefixWorkingFolderAction
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CollectionUtil.Merge<ContextMissmatch, ContextMissmatch, ContextMissmatch>(
        base.Compatible(ctx),
        CheckContext(ctx, Create(Keys.Iterations))
        );
    }

    protected override string Prefix(Context ctx)
    {
      return Keys.Iterations.Get(ctx).Steps.ToString();
    }
  }
}