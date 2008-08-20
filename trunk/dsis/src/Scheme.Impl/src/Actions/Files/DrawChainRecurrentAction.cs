using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawChainRecurrentAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), 
        Create(Keys.GraphComponents<Q>()),
        Create(FileKeys.WorkingFolderKey));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      WorkingFolderInfo folderInfo = FileKeys.WorkingFolderKey.Get(input);
      IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(input);

      string outputFile = folderInfo.CreateFileName("chain-recurrent-picture.png");      
      var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      var data = new double[Dimension];

      foreach (INode<Q> node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          string gnuplotComponent = folderInfo.CreateFileName("chain-recurrent-picture-" + ++components);

          fw = new GnuplotPointsFileWriter(gnuplotComponent, Dimension);
          files[info] = fw;
        }

        ((IIntegerCoordinateSystem<Q>)comps.CoordinateSystem).CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      IGnuplotPhaseScriptGen gen = GnuplotSriptGen.ScriptGen(
        Dimension,
        folderInfo.CreateFileName("chain-recurrent-picture-script.gnuplot"),
        new GnuplotScriptParameters(outputFile, ""));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Finish();

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);
    }
  }
}
