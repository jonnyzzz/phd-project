using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawChainRecurrentAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), 
        Create(Keys.GraphComponents<Q>()),
        Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo folderInfo = FileKeys.WorkingFolderKey.Get(input);
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      string outputFile = folderInfo.CreateFileName("chain-recurrent-picture.png");      
      var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[system.Dimension];

      foreach (INode<Q> node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          string gnuplotComponent = folderInfo.CreateFileName("chain-recurrent-picture-" + ++components);

          fw = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
          files[info] = fw;
        }
        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      IGnuplotPhaseScriptGen gen = GnuplotSriptGen.ScriptGen(
        system.Dimension,
        folderInfo.CreateFileName("chain-recurrent-picture-script.gnuplot"),
        new GnuplotScriptParameters(outputFile, ""));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}
