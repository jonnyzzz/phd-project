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
      var sys = (IIntegerCoordinateSystem<T>) file.First;
      var data = new double[] {0, 0};

      var wr = new GnuplotPointsFileWriter(this, "measure3d_value.data", 3);
      foreach (var pair in file.Second)
      {
        sys.CenterPoint(pair.Key, data);
        wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
      }
      return new[] {wr};
    }

    public override string DrawImage(string suffix)
    {
      if (Wights == null)
        return null;

      string outputFile = CreateFileName(suffix + "measure3d_segments.png");

      string title = string.Format("{1} Entropy = {0}", Entropy.Value.ToString("F6"), Title);
      var ps = new GnuplotScriptParameters(outputFile, title) {ForcePoints = true};
      IGnuplotPhaseScriptGen gen = new GnuplotEntropy3dScriptGen(this, ps);

      foreach (var file in Render(Wights.Value))
        gen.AddPointsFile(file.CloseFile());

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen.CloseFile());

      return outputFile;
    }
  }
}