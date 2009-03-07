using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyWithSpace3d<T> : DrawEntropyWithSpaceBase<T>
    where T : IIntegerCoordinate
  {
    private IEnumerable<GnuplotPointsFileWriter> Render(Pair<ICellCoordinateSystem<T>, IDictionary<T, double>> file)
    {
      var sys = (IIntegerCoordinateSystem<T>) file.First;
      var data = new double[2] {0, 0};
      GnuplotPointsFileWriter wr;
      GnuplotPointsFileWriter wrz;

      using (wr = new GnuplotPointsFileWriter(CreateFileName("measure3d_value.data"), 3))
      using (wrz = new GnuplotPointsFileWriter(CreateFileName("measure3d_zero.data"), 3))
      {
        foreach (KeyValuePair<T, double> pair in file.Second)
        {
          T key = pair.Key;
          sys.CenterPoint(key, data);
          wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
          wrz.WritePoint(new ImagePoint(data[0], data[1], 0));
        }
      }

      return new[] {wr, wrz};
    }

    public override string DrawImage(string suffix)
    {
      if (Wights == null)
        return null;


      string outputFile = CreateFileName(suffix + "measure3d.png");

      var ps = new GnuplotScriptParameters3d(outputFile,
                                             string.Format("Title {1} Entropy = {0}", Entropy.Value.ToString("F6"), Title));
      ps.ForcePoints = true;
      ps.RotX = 75;
      ps.RotZ = 30;
      ps.XYPane = 0;
      IGnuplotPhaseScriptGen gen = new Gnuplot3dScriptGen(CreateFileName("measure3d.gnuplot"), ps);

      foreach (var file in Render(Wights.Value))
        gen.AddPointsFile(file);

      gen.Finish();

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);

      return "";
    }
  }
}