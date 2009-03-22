using System;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawChainRecurrentAction : AbstractDrawChainAction
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      base.GetChecks<T,Q>(system, addCheck);
      addCheck(Create(FileKeys.WorkingFolderKey));
    }

    protected override WorkingFolderInfo GetWorkingFolderInfo(IReadOnlyContext input)
    {
      return FileKeys.WorkingFolderKey.Get(input);
    }

    protected override void DrawFromScript(IGnuplotScript gen)
    {
      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}
