using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public static class EntropyDrawColorMapHelper
  {
    public static void RenderMeasure<Q>(WorkingFolderInfo info, IGraphMeasure<Q> measure, Action<Q, double[]> centerPoint)
      where Q : ICellCoordinate
    {
      var data = new double[2];
      var wr = new GnuplotPointsFileWriter(info, "measure-color-map.data", 3);
      foreach (var pair in measure.GetMeasureNodes())
      {
        Q key = pair.Key;
        centerPoint(key, data);
        wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
      }

      string outputFile = info.CreateFileName("measure-color-map.png");

      var ps = new GnuplotScriptParameters(outputFile, string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")));
      var gen = GnuplotSriptGen.Entrorpy2d(info, ps);

      gen.AddPointsFile(wr.CloseFile());

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen.CloseFile());
    }    
  }
}