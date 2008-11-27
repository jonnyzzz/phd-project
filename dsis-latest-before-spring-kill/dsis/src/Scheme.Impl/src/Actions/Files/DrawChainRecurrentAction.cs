using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawChainRecurrentAction : AbstractDrawChainAction
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), 
        Create(FileKeys.WorkingFolderKey));
    }

    protected override WorkingFolderInfo GetWorkingFolderInfo(IReadOnlyContext input)
    {
      return FileKeys.WorkingFolderKey.Get(input);
    }

    protected override void DrawFromScript(IGnuplotPhaseScriptGen gen)
    {
      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}
