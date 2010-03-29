using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Line;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawLineActionBase : LineBaseAction
  {
    protected override void Apply(ILine line, Context ctx, Context result)
    {
      var info = GetTempInfo(ctx);

      var image = info.NewFile("line.png");
      var ps = new GnuplotScriptParameters(image, "Line") {ShowKeyHistory = false, ForcePoints = true};
      
      if (ctx.ContainsKey(ImageDimension.KEY))
      {
        var d = ImageDimension.KEY.Get(ctx);
        ps.Width = d.Width;
        ps.Height = d.Height;
      }

      var gen = GnuplotSriptGen.CreateLines(info, ps);

      foreach (var point in line.Points)
      {
        var wr = new LinePointsFile(info, "line.data", line.Dimension, string.Format("Points {0}", line.Count));
        point.Visit(l => wr.WritePoint(new ImagePoint(l)));
        gen.AddFile(wr.CloseFile());
      }

      DrawFromScript(gen.CloseFile());      
      FileKeys.ImageKey.Set(result, new ImageResult(image));
    }

    protected abstract ITempFileFactory GetTempInfo(Context ctx);

    protected abstract void DrawFromScript(IGnuplotScript file);
  }
}