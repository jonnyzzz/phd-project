using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyWithSpace3dSegments<T> : DrawEntropyWithSpaceBase<T>
    where T : IIntegerCoordinate
  {
    private IEnumerable<GnuplotPointsFileWriter> Render(Pair<ICellCoordinateSystem<T>, IDictionary<T, double>> file)
    {
      IIntegerCoordinateSystem<T> sys = (IIntegerCoordinateSystem<T>)file.First;
      double[] data = new double[2] { 0, 0 };
      GnuplotPointsFileWriter wr;

      using (wr = new GnuplotPointsFileWriter(CreateFileName("measure3d_value.data"), 3))
      {
          foreach (KeyValuePair<T, double> pair in file.Second)
          {
            sys.CenterPoint(pair.Key, data);
            wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
          }
      }
      return new GnuplotPointsFileWriter[] { wr };
    }

    public override string DrawImage(string suffix)
    {
      if (Wights == null)
        return null;


      string outputFile = CreateFileName(suffix + "measure3d_segments.png");

      GnuplotScriptParameters ps = new GnuplotScriptParameters(outputFile,
                                                               Title +
                                                               string.Format("Entropy = {0}",
                                                                             Entropy.Value.ToString("F6")));
      ps.ForcePoints = true;
      IGnuplotPhaseScriptGen gen = new GnuplotEntropy3dScriptGen(
                                                             CreateFileName("measure3d_segments.gnuplot"),
                                                             ps);

      foreach (GnuplotPointsFileWriter file in Render(Wights.Value))
        gen.AddPointsFile(file);

      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);

      return outputFile;
    }
  }
}