using System.Collections.Generic;
using System.IO;
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
      var info = FileKeys.WorkingFolderKey.Get(ctx);
      var prefix = info.Prefix(Prefix(ctx));
      if (!Directory.Exists(prefix.Path))
        Directory.CreateDirectory(prefix.Path);

      FileKeys.WorkingFolderKey.Set(result, prefix);
    }
  }
}