using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public static class EntropyDrawColorMapHelper
  {
    public static void RenderMeasure<Q>(WorkingFolderInfo info, IGraphMeasure<Q> measure, Action<Q, double[]> centerPoint, string fileName = "measure-color-map.png")
      where Q : ICellCoordinate
    {
      RenderMeasure(info, measure.GetMeasureNodes(), centerPoint, fileName, string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")));      
    }

    public static void RenderMeasure<Q>(WorkingFolderInfo info, IEnumerable<KeyValuePair<Q, double>> measure, Action<Q, double[]> centerPoint, string fileName, string text)
    {
      var data = new double[2];
      var wr = new GnuplotPointsFileWriter(info, "measure-color-map.data", 3);
      foreach (var pair in measure)
      {
        Q key = pair.Key;
        centerPoint(key, data);
        wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
      }

      string outputFile = info.CreateFileName(fileName);

      var ps = new GnuplotScriptParameters(outputFile, text);
      var gen = GnuplotSriptGen.Entrorpy2d(info, ps);

      gen.AddPointsFile(wr.CloseFile());

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen.CloseFile());
    }    
  }
}