using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IoCDrawLineAction : DrawLineActionBase
  {
    private readonly GnuplotDrawer.GnuplotDrawer myDrawer;
    private readonly ITempFileFactory myInfo;

    public IoCDrawLineAction(GnuplotDrawer.GnuplotDrawer drawer, ITempFileFactory info)
    {
      myDrawer = drawer;
      myInfo = info;
    }

    protected override ITempFileFactory GetTempInfo(Context ctx)
    {
      return myInfo;
    }

    protected override void DrawFromScript(IGnuplotScript file)
    {
      myDrawer.DrawImage(file).WaitForExit();
    }
  }
}