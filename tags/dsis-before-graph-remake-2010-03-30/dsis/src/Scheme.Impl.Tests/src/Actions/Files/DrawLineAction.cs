using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Line;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawLineAction : LineBaseAction
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, base.Compatible(ctx), Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply(ILine line, Context ctx, Context result)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(ctx);

      GnuplotScriptParameters ps = new GnuplotScriptParameters(info.CreateFileName("line.png"), "Line");
      ps.ShowKeyHistory = false;

      IGnuplotLineScriptGen gen = GnuplotSriptGen.CreateLines(info.CreateFileName("line.gnuplot"), ps);

      using(GnuplotPointsFileWriter wr = new GnuplotPointsFileWriter(info.CreateFileName("line.data"), line.Dimension))
      {
        line.Save(wr.Writer);
        gen.AddFile(wr.Filename, "");
      }
      gen.Finish();

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen);      
    }
  }
}