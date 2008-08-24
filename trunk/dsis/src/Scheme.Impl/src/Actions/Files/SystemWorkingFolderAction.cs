using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class SystemWorkingFolderAction : PrefixWorkingFolderAction
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CollectionUtil.Merge<ContextMissmatch, ContextMissmatch, ContextMissmatch>(
        base.Compatible(ctx),
         CheckContext(ctx, Create( Keys.SystemInfoKey))
      );
    }

    protected override string Prefix(Context ctx)
    {
      ISystemInfo system = Keys.SystemInfoKey.Get(ctx);
      return system.PresentableName;
    }
  }
}