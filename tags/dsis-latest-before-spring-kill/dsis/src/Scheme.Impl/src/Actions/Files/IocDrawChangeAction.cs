using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IocDrawChangeAction : AbstractDrawChainAction
  {
    private readonly GnuplotDrawer.GnuplotDrawer myDrawer;
    private readonly WorkingFolderInfo myInfo;

    //TODO: Move to context level
    public int Height { get; set; }
    public int Width { get; set; }

    public IocDrawChangeAction(GnuplotDrawer.GnuplotDrawer drawer, WorkingFolderInfo info)
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

    protected override GnuplotScriptParameters CreateOutputParameters(string outputFile)
    {
      var paramz = base.CreateOutputParameters(outputFile);
      paramz.Height = Height;
      paramz.Width = Width;
      return paramz;
    }
  }
}