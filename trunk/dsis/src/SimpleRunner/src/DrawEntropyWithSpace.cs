using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyWithSpace<T> : DrawEntropyWithSpaceBase<T> 
    where T : IIntegerCoordinate
  {
    private GnuplotPointsFileWriter Render(Pair<ICellCoordinateSystem<T>, IDictionary<T, double>> file)
    {
      var sys = (IIntegerCoordinateSystem<T>) file.First;
      var data = new double[2];
      using (var wr = new GnuplotPointsFileWriter(CreateFileName("measure.data"), 3))
      {
        foreach (KeyValuePair<T, double> pair in file.Second)
        {
          T key = pair.Key;
          sys.CenterPoint(key, data);
          wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
        }

        return wr;
      }
    }

    public override string DrawImage(string suffix)
    {
      if (Wights == null)
        return null;

      var file = Render(Wights.Value).CloseFile();
      
      string outputFile = CreateFileName(suffix + "measure.png");

      var ps = new GnuplotScriptParameters(outputFile,
                                           Title + string.Format("Entropy = {0}", Entropy.Value.ToString("F6")));
      IGnuplotPhaseScriptGen gen = GnuplotSriptGen.Entrorpy2d(
        CreateFileName("measure.gnuplot"),
        ps);

      gen.AddPointsFile(file);

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen.CloseFile());

      return "";
    }
  }
}