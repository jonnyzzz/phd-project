using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
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

      var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      int components = 0;
      var data = new double[system.Dimension];

      foreach (var node in comps.GetNodes(comps.Components))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (!files.TryGetValue(info, out fw))
        {
          //TODO: FixMe
          fw = new GnuplotPointsFileWriter(null, myTitle + "-" + ++components, system.Dimension);
          files[info] = fw;
        }
        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }
      
      //TODO: FixMe
      var gen = GnuplotSriptGen.ScriptGen(
        system.Dimension, null,
        new GnuplotScriptParameters(outputFile, myTitle));

      foreach (GnuplotPointsFileWriter file in files.Values)
      {
        gen.AddPointsFile(file.CloseFile());
      }

      var drw = new GnuplotDrawer.GnuplotDrawer();
      drw.DrawImage(gen.CloseFile());

      FireListeners(lis => lis.ImageFile(outputFile));
    }
  }
}