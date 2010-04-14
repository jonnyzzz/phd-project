using System;
using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IocDrawSimbolicImageAction : AbstractDrawChainAction
  {
    private readonly GnuplotDrawer.GnuplotDrawer myDrawer;
    private readonly ITempFileFactory myInfo;

    public IocDrawSimbolicImageAction(GnuplotDrawer.GnuplotDrawer drawer, ITempFileFactory info)
    {
      myDrawer = drawer;
      myInfo = info;
    }

    protected override IComponentPointsWriter CreateComponentWriter(ITempFileFactory folderInfo)
    {
      return new CachedComponetPointsWriter(base.CreateComponentWriter(folderInfo));
    }

    protected override ITempFileFactory GetWorkingFolderInfo(IReadOnlyContext input)
    {
      return myInfo;
    }

    protected override void DrawFromScript(IGnuplotScript gen)
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