using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasure3dWithBaseAction : DrawEntropy3dActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);
      IGraphStrongComponents<Q> components = Keys.GraphComponents<Q>().Get(input);

      GnuplotPointsFileWriter wr;
      wr = WriteMeasureFile(info.CreateFileName("measure3d_base_value.data"), measure, system);

      string outputFile = info.CreateFileName("measure3d_base.png");

      GnuplotScriptParameters3d ps = CreateProperties(measure, outputFile);

      GnuplotEntropy3dWithBaseScriptGen gen = new GnuplotEntropy3dWithBaseScriptGen(info.CreateFileName("measure3d_base.gnuplot"), ps);

      GnuplotPointsFileWriter bs;
      using(bs = new GnuplotPointsFileWriter(info.CreateFileName("measure3d_base_vbase.data"), 2))
      {
        double[] data = new double[2];
        foreach (Q q in components.GetCoordinates(new List<IStrongComponentInfo>(components.Components)))
        {
          system.CenterPoint(q, data);
          bs.WritePoint(new ImagePoint(data));
        }
      }

      gen.AddPointsFile(wr, bs);
      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }

  }
}