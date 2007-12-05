using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasure3dAction : DrawEntropyMeasureActionBase
  {

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);

      double[] data = new double[2] { 0, 0 };
      GnuplotPointsFileWriter wr;

      using (wr = new GnuplotPointsFileWriter(info.CreateFileName("measure3d_value.data"), 3))
      {
        foreach (KeyValuePair<Q, double> pair in measure.GetMeasureNodes())
        {
          system.CenterPoint(pair.Key, data);
          wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
        }
      }
      
      string outputFile = info.CreateFileName("measure3d_segments.png");

      GnuplotScriptParameters3d ps = new GnuplotScriptParameters3d(outputFile,
                                                               string.Format("Entropy = {0}",
                                                                             measure.GetEntropy().ToString("F6")));
      ps.ForcePoints = true;
      ps.RotX = 75;
      ps.RotZ = 30;
      ps.XYPane = 0;

      ps.ForcePoints = true;
      IGnuplotPhaseScriptGen gen = new GnuplotEntropy3dScriptGen(
                                                             info.CreateFileName("measure3d_segments.gnuplot"),
                                                             ps);

      gen.AddPointsFile(wr);
      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}