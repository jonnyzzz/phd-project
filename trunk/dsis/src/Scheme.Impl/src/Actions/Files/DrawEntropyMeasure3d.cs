using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasure3dAction : DrawEntropy3dActionBase
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      
      GnuplotPointsFileWriter wr;
      wr = WriteMeasureFile(info.CreateFileName("measure3d_value.data"), measure, system);

      string outputFile = info.CreateFileName("measure3d_segments.png");

      GnuplotScriptParameters3d ps = CreateProperties(measure, outputFile);

      IGnuplotPhaseScriptGen gen = new GnuplotEntropy3dScriptGen(info.CreateFileName("measure3d_segments.gnuplot"), ps);

      gen.AddPointsFile(wr);
      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}