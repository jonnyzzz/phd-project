using System.Collections.Generic;
using System.IO;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public interface IDrawLastComputationResultEvents
  {
    void ImageFile(string file);
  }

  public class DrawLastComputationResultListener<T,Q> : ProvideExternalListenerBase<T,Q, IDrawLastComputationResultEvents>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly string myPath;

    public DrawLastComputationResultListener(string path)
    {
      myPath = path;
    }

    private static string ToSafePath(string s)
    {
      return s.Replace("`", "_").Replace(",", ".").Replace(" ", "_");
    }

    private static string CreateTitle(AbstractImageBuilderContext<Q> cx)
    {
      return ToSafePath(string.Format("{0}-{1}", cx.Info.PresentableName, cx.Builder.PresentableName));
    }

    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      string title = CreateTitle(cx);

      string path = Path.Combine(myPath, title);
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter> files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[system.SystemSpace.Dimension];

      foreach (INode<Q> node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          fw = new GnuplotPointsFileWriter(Path.Combine(path, title + "-" + ++components), system.SystemSpace.Dimension);
          files[info] = fw;
        }
        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      string outputFile = Path.Combine(path, "-" + title + "-picture.png");
      IGnuplotScriptGen gen = GnuplotSriptGen.ScriptGen(
        system.SystemSpace.Dimension,
        Path.Combine(path, title + "-script.gnuplot"),
        new GnuplotScriptParameters(outputFile, title));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Dispose();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);

      FireListeners(delegate(IDrawLastComputationResultEvents lis) { lis.ImageFile(outputFile);});
    }
  }
}