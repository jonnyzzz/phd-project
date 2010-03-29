using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBase : DrawEntropyMeasureActionBaseBase
  {
    protected abstract GnuplotScriptParameters CreateProperties<Q>(IGraphMeasure<Q> measure, string outputFile)
      where Q : ICellCoordinate;

    protected abstract override int SystemDimension { get; }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      IGraphStrongComponents<Q> components = Keys.GraphComponents<Q>().Get(input);

      GnuplotPointsFileWriter wr = WriteMeasureFile(info.CreateFileName("measure_base_value.data"), measure, system);

      string outputFile = info.CreateFileName("measure_base.png");

      var ps = CreateProperties(measure, outputFile);

      IGnuplotEntropyScriptGen gen = CreateScriptGen(info.CreateFileName("measure_base.gnuplot"), ps);

      GnuplotPointsFileWriter bs;
      using (bs = new GnuplotPointsFileWriter(info.CreateFileName("measure_base_vbase.data"), SystemDimension))
      {
        var data = new double[SystemDimension];
        foreach (Q q in components.GetCoordinates(new List<IStrongComponentInfo>(components.Components)))
        {
          system.CenterPoint(q, data);
          bs.WritePoint(new ImagePoint(data));
        }
      }

      gen.AddPointsFile(wr, bs);
      gen.Finish();

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }

    protected abstract IGnuplotEntropyScriptGen CreateScriptGen(string file, GnuplotScriptParameters ps);    
  }
}