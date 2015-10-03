using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawLineAction : DrawLineActionBase 
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, base.Compatible(ctx), Create(FileKeys.WorkingFolderKey));
    }

    protected override ITempFileFactory GetTempInfo(Context ctx)
    {
      return FileKeys.WorkingFolderKey.Get(ctx);
    }

    protected override void DrawFromScript(IGnuplotScript file)
    {
      new GnuplotDrawer.GnuplotDrawer().DrawImage(file);
    }
  }
}