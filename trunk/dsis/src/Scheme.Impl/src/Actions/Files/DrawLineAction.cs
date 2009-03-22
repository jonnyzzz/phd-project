using System.Collections.Generic;
using DSIS.Core.Visualization;
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
      var info = FileKeys.WorkingFolderKey.Get(ctx);

      var ps = new GnuplotScriptParameters(info.CreateFileName("line.png"), "Line") {ShowKeyHistory = false};

      var gen = GnuplotSriptGen.CreateLines(info.CreateFileName("line.gnuplot"), ps);

      var wr = new LinePointsFile(info.CreateFileName("line.data"), line.Dimension, string.Format("Points {0}", line.Count));
      {
        line.Visit(l=>wr.WritePoint(new ImagePoint(l)));
        gen.AddFile(wr.CloseFile());
      }

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen.CloseFile());      
    }
  }
}