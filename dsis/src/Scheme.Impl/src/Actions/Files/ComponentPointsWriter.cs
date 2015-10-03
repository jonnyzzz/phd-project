using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class ComponentPointsWriter : IComponentPointsWriter
  {
    private readonly ITempFileFactory myFolderInfo;
    private const int COMPONENTS_TO_SHOW = 15;

    public ComponentPointsWriter(ITempFileFactory folderInfo)
    {
      myFolderInfo = folderInfo;
    }

    public IEnumerable<IGnuplotPointsFile> WriteComponents<T, Q>(T system, IGraphStrongComponents<Q> comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
      GnuplotPointsFileWriter otherFilesWriter = null;

      int components = 0;
      var data = new double[system.Dimension];

      var componentIds = new List<IStrongComponentInfo>(comps.Components);
      componentIds.Sort((c1, c2) => -c1.NodesCount.CompareTo(c2.NodesCount));

      
      var bigerComps = new HashSet<IStrongComponentInfo>(componentIds.Take(COMPONENTS_TO_SHOW));

      foreach (var node in comps.GetNodes(componentIds))
      {
        var info = comps.GetNodeComponent(node);
        if (info == null)
          continue;

        GnuplotPointsFileWriter fw;
        if (bigerComps.Contains(info))
        {
          if (!files.TryGetValue(info, out fw))
          {
            fw = new GnuplotPointsFileWriter(myFolderInfo, "chain-recurrent-picture-" + ++components + ".data", system.Dimension);
            files[info] = fw;
          }
        }
        else
        {
          if (otherFilesWriter == null)
          {
            otherFilesWriter = new GnuplotPointsFileWriter(myFolderInfo, "chain-recurrent-picture-other", system.Dimension);
          }
          fw = otherFilesWriter;
        }

        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      var result = componentIds.Where(files.ContainsKey).Select(x => files[x]);
      if (otherFilesWriter != null)
      {
        result = otherFilesWriter.Enum().Join(result);
      }
      return result.Select(x=>x.CloseFile());
    }
  }
}