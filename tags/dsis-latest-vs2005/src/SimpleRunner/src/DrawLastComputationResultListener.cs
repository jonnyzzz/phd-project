using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public interface IDrawLastComputationResultEvents
  {
    void ImageFile(string file);
  }

  public class DrawLastComputationResultListener<T,Q> : ProvideExternalListenerBase<T,Q, IDrawLastComputationResultEvents>, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private string myTitle;
    private string myPath;

      
    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get { yield return new Pair<string, Action<string>>("{0}", delegate(string path) { myPath = path; }); }
    }

    public void ComputationTitle(string title)
    {
      myTitle = title;
    }

    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      string path = myPath;
      string outputFile = Path.Combine(path, "-" + myTitle + "-picture.png");

      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter> files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      double[] data = new double[system.Dimension];

      foreach (INode<Q> node in comps.GetNodes(new List<IStrongComponentInfo>(comps.Components)))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          string gnuplotComponent = Path.Combine(path, myTitle + "-" + ++components);

          fw = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
          files[info] = fw;
        }
        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }
      
      IGnuplotPhaseScriptGen gen = GnuplotSriptGen.ScriptGen(
        system.Dimension,
        Path.Combine(path, myTitle + "-script.gnuplot"),
        new GnuplotScriptParameters(outputFile, myTitle));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Finish();

      GnuplotDrawer.GnuplotDrawer drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen);

      FireListeners(delegate(IDrawLastComputationResultEvents lis) { lis.ImageFile(outputFile);});
    }
  }
}