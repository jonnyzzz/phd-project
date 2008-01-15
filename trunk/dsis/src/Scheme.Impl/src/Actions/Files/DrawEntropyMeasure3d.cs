using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropy3dActionBase : DrawEntropyMeasureActionBase
  {
    protected static GnuplotScriptParameters3d CreateProperties<Q>(IGraphMeasure<Q> measure, string outputFile) 
      where Q : ICellCoordinate
    {
      GnuplotScriptParameters3d ps = new GnuplotScriptParameters3d(outputFile, string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")));
      ps.ForcePoints = true;
      ps.RotX = 75;
      ps.RotZ = 30;
      ps.XYPane = 0;
      ps.ForcePoints = true;
      return ps;
    }

    protected static GnuplotPointsFileWriter WriteMeasureFile<T, Q>(string measureFile, IGraphMeasure<Q> measure, T system)
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
    {
      GnuplotPointsFileWriter wr;
      double[] data = new double[2] { 0, 0 };
      using (wr = new GnuplotPointsFileWriter(measureFile, 3))
      {
        foreach (KeyValuePair<Q, double> pair in measure.GetMeasureNodes())
        {
          system.CenterPoint(pair.Key, data);
          wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
        }
      }
      return wr;
    }
  }

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