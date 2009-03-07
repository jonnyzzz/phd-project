using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IocDrawSimbolicImageAction : AbstractDrawChainAction
  {
    private readonly GnuplotDrawer.GnuplotDrawer myDrawer;
    private readonly WorkingFolderInfo myInfo;

    public IocDrawSimbolicImageAction(GnuplotDrawer.GnuplotDrawer drawer, WorkingFolderInfo info)
    {
      myDrawer = drawer;
      myInfo = info;
    }

    protected override WorkingFolderInfo GetWorkingFolderInfo(IReadOnlyContext input)
    {
      return myInfo;
    }

    protected override void DrawFromScript(IGnuplotPhaseScriptGen gen)
    {
      myDrawer.DrawImage(gen).WaitForExit();
    }

    protected override GnuplotScriptParameters CreateOutputParameters(IReadOnlyContext context, string outputFile)
    {
      var ps = base.CreateOutputParameters(context, outputFile);
      ps.DrawScans = false;
      return ps;
    }
  }
}