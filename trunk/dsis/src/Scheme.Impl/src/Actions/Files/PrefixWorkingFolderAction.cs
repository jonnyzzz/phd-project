using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class PrefixWorkingFolderAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(FileKeys.WorkingFolderKey));
    }

    protected abstract string Prefix(Context ctx);

    protected override void Apply(Context ctx, Context result)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(ctx);
      FileKeys.WorkingFolderKey.Set(result, info.Prefix(Prefix(ctx)));
    }
  }
}