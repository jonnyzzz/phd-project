using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyWithSpace<T> : DrawBase
    where T : IIntegerCoordinate<T>
  {
    private Pair<ICellCoordinateSystem<T>, IDictionary<T, double>>? myWights = null;
    private double? myEntropy = null;

    public void SetMeasure(ICellCoordinateSystem<T> system, IDictionary<T, double> measure, double entropy)
    {
      myWights = new Pair<ICellCoordinateSystem<T>, IDictionary<T, double>>(system, measure);
      myEntropy = entropy;
    }

    private GnuplotPointsFileWriter Render(Pair<ICellCoordinateSystem<T>, IDictionary<T, double>> file)
    {
      IIntegerCoordinateSystem<T> sys = (IIntegerCoordinateSystem<T>) file.First;
      double[] data = new double[2];
      using (GnuplotPointsFileWriter wr = new GnuplotPointsFileWriter(CreateFileName("measure.data"), 3))
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
      if (myWights == null)
        return null;

      GnuplotPointsFileWriter file = Render(myWights.Value);
      {
        string outputFile = CreateFileName(suffix + "measure.png");

        GnuplotScriptParameters ps = new GnuplotScriptParameters(outputFile, Title + string.Format("Entropy = {0}", myEntropy.Value.ToString("F6")));
        IGnuplotPhaseScriptGen gen = GnuplotSriptGen.Entrorpy2d(
          CreateFileName("measure.gnuplot"),
          ps);

        gen.AddPointsFile(file);

        gen.Finish();

        GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
        drw.DrawImage(gen);
      }

      return "";
    }
  }
}