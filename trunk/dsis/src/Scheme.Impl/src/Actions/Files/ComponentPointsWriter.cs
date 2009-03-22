using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class ComponentPointsWriter
  {
    private readonly WorkingFolderInfo myFolderInfo;
    private const int COMPONENTS_TO_SHOW = 15;

    public ComponentPointsWriter(WorkingFolderInfo folderInfo)
    {
      myFolderInfo = folderInfo;
    }

    public IEnumerable<GnuplotPointsFileWriter> WriteComponents<T, Q>(T system, IGraphStrongComponents<Q> comps)
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
            string gnuplotComponent = myFolderInfo.CreateFileName("chain-recurrent-picture-" + ++components);

            fw = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
            files[info] = fw;
          }
        }
        else
        {
          if (otherFilesWriter == null)
          {
            string gnuplotComponent = myFolderInfo.CreateFileName("chain-recurrent-picture-other");
            otherFilesWriter = new GnuplotPointsFileWriter(gnuplotComponent, system.Dimension);
          }
          fw = otherFilesWriter;
        }

        system.CenterPoint(node.Coordinate, data);
        fw.WritePoint(new ImagePoint(data));
      }

      var result = componentIds.Select(x => files[x]);
      if (otherFilesWriter != null)
      {
        result = otherFilesWriter.Enum().Join(result);
      }
      return result;
    }
  }
}