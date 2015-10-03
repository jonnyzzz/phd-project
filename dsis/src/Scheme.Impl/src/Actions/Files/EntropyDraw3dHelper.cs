using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public static class EntropyDraw3dHelper
  {
    public static void RenderMeasure<Q>(WorkingFolderInfo info, IGraphMeasure<Q> measure, Action<Q, double[]> centerPoint)
      where Q : ICellCoordinate
    {
      var data = new double[2];
      var wr3 = new GnuplotPointsFileWriter(info, "measure-color-map.data", 3);
      var wrbase = new GnuplotPointsFileWriter(info, "measure-color-base.data", 3);
      foreach (var pair in measure.GetMeasureNodes())
      {
        Q key = pair.Key;
        centerPoint(key, data);
        wr3.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
        wrbase.WritePoint(new ImagePoint(data[0], data[1], 0));
      }

      string outputFile = info.CreateFileName("measure-color-map.png");

      var title = string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6"));
      var ps = new GnuplotScriptParameters3d(outputFile, title)
                 {
                   ForcePoints = true,
                   RotX = 75,
                   RotZ = 30,
                   XYPane = 0,
                 };
      var gen = new GnuplotEntropy3dWithBaseScriptGen(info, ps);
      gen.AddPointsFile(wr3.CloseFile(), wrbase.CloseFile());

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen.CloseFile());      
    }
  }
}