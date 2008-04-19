using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Line;

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
}