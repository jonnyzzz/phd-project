using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureColorMapAction : DrawEntropyMeasureActionBaseBase
  {
    protected override void Apply<T, Q>(Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);

      var data = new double[2];
      GnuplotPointsFileWriter wr;
      using (wr = new GnuplotPointsFileWriter(info.CreateFileName("measure-color-map.data"), 3))
      {
        foreach (var pair in measure.GetMeasureNodes())
        {
          Q key = pair.Key;
          ((IIntegerCoordinateSystem<Q>)measure.CoordinateSystem).CenterPoint(key, data);
          wr.WritePoint(new ImagePoint(data[0], data[1], pair.Value));
        }
      }

      string outputFile = info.CreateFileName("measure-color-map.png");

      var ps = new GnuplotScriptParameters(outputFile,
                                           string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")));
      IGnuplotPhaseScriptGen gen = GnuplotSriptGen.Entrorpy2d(
        info.CreateFileName("measure-color-map.gnuplot"), ps);

      gen.AddPointsFile(wr);
      gen.Finish();

      new GnuplotDrawer.GnuplotDrawer().DrawImage(gen);
    }

    public override int SystemDimension
    {
      get { return 2; }
    }
  }
}