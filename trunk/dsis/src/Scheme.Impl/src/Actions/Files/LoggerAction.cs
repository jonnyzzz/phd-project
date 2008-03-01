using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class LoggerAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      WorkingFolderInfo folder = FileKeys.WorkingFolderKey.Get(ctx);
      Logger logger = new Logger(folder);
      FileKeys.LoggerKey.Set(result, logger);
    }
  }
}