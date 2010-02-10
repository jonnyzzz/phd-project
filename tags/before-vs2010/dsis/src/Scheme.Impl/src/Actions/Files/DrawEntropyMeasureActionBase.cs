using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBase : DrawEntropyMeasureActionBaseBase
  {
    protected abstract GnuplotScriptParameters CreateProperties<Q>(IGraphMeasure<Q> measure, string outputFile)
      where Q : ICellCoordinate;

    public event Action<GnuplotScriptParameters> UpdateParameters;

    public abstract override int SystemDimension { get; }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      var info = FileKeys.WorkingFolderKey.Get(input);
      var measure = Keys.GraphMeasure<Q>().Get(input);
      var wr = WriteMeasureFile(info.ApplyPrefix("measure_base_value.data", ""), measure);

      var outputFile = info.CreateFileName("measure_base.png");

      var ps = CreateProperties(measure, outputFile);

      if (UpdateParameters != null)
        UpdateParameters(ps);

      if (input.ContainsKey(ImageDimension.KEY))
      {
        var d = ImageDimension.KEY.Get(input);
        ps.Width = d.Width;
        ps.Height = d.Height;
      }

      var gen = CreateScriptGen(info.ApplyPrefix("measure_base", ""), ps);

      var bs = new GnuplotPointsFileWriter(info, "measure_base_vbase.data", SystemDimension);
      var data = new double[SystemDimension];
      foreach (var q in measure.GetMeasureNodes())
      {
        ((IIntegerCoordinateSystem<Q>) measure.CoordinateSystem).CenterPoint(q.Key, data);
        bs.WritePoint(new ImagePoint(data));
      }
/*
        foreach (Q q in components.GetCoordinates(new List<IStrongComponentInfo>(components.Components)))
        {
          ((IIntegerCoordinateSystem<Q>)components.CoordinateSystem).CenterPoint(q, data);
          bs.WritePoint(new ImagePoint(data));
        }
*/

      gen.AddPointsFile(wr.CloseFile(), bs.CloseFile());

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen.CloseFile()).WaitForExit();

      FileKeys.ImageKey.Set(output, new ImageResult(outputFile));
    }

    protected abstract IGnuplotMeasureDensityScriptGen2 CreateScriptGen(ITempFileFactory factory, GnuplotScriptParameters ps);    
  }
}