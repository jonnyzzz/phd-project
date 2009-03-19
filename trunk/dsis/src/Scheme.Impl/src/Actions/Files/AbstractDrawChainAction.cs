using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class AbstractDrawChainAction : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      addCheck(Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo folderInfo = GetWorkingFolderInfo(input);
      IGraphStrongComponents<Q> comps = Keys.GetGraphComponents<Q>().Get(input);

      string outputFile = folderInfo.CreateFileName("chain-recurrent-picture.png");
      var result = new ImageResult(outputFile);

      var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      GnuplotPointsFileWriter otherFilesWriter = null;

      int components = 0;
      var data = new double[system.Dimension];

      var componentIds = new List<IStrongComponentInfo>(comps.Components);
      componentIds.Sort((c1, c2) => -c1.NodesCount.CompareTo(c2.NodesCount));

      const int COMPONENTS_TO_SHOW = 15;
      var bigerComps = new HashSet<IStrongComponentInfo>(componentIds.Take(COMPONENTS_TO_SHOW));
      
      foreach (INode<Q> node in comps.GetNodes(componentIds))
      {
        IStrongComponentInfo info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (bigerComps.Contains(info))
        {
          if (!files.TryGetValue(info, out fw))
          {
            string gnuplotComponent = folderInfo.CreateFileName("chain-recurrent-picture-" + ++components);

            fw = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
            files[info] = fw;
          }
        }
        else
        {
          if (otherFilesWriter == null)
          {
            string gnuplotComponent = folderInfo.CreateFileName("chain-recurrent-picture-other");
            otherFilesWriter = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
          }
          fw = otherFilesWriter;
        }
        
        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      var gen = GnuplotSriptGen.ScriptGen(
        system.Dimension,
        folderInfo.CreateFileName("chain-recurrent-picture-script.gnuplot"),
        CreateOutputParameters(input, outputFile));

      IEnumerable<GnuplotPointsFileWriter> values = files.Values;
      if (otherFilesWriter != null)
      {
        values = values.Join(otherFilesWriter);
      }
      foreach (var file in values)
      {
        file.Dispose();
        gen.AddPointsFile(file);
      }

      gen.Finish();

      DrawFromScript(gen);

      FileKeys.ImageKey.Set(output, result);
    }

    protected virtual GnuplotScriptParameters CreateOutputParameters(IReadOnlyContext context, string outputFile)
    {
      var ps = new GnuplotScriptParameters(outputFile, "");
      if (context.ContainsKey(ImageDimension.KEY))
      {
        var d = ImageDimension.KEY.Get(context);
        ps.Width = d.Width;
        ps.Height = d.Height;
      }
      return ps;
    }

    protected abstract void DrawFromScript(IGnuplotPhaseScriptGen gen);

    protected abstract WorkingFolderInfo GetWorkingFolderInfo(IReadOnlyContext input);    
  }
}