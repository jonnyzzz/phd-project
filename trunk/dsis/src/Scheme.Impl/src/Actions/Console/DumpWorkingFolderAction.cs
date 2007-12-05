using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpWorkingFolderAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      System.Console.Out.WriteLine("Working folder is {0}", FileKeys.WorkingFolderKey.Get(ctx).Path);
    }
  }
}