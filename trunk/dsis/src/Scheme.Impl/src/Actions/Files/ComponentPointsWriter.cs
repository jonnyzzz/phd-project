using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
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

    public IEnumerable<IGnuplotPointsFile> WriteComponents<T, Q>(T system, IReadonlyGraphStrongComponents<Q> comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      var action = new Action<T,Q>(system, myFolderInfo);
      comps.DoGeneric(action);
      return action.Result;
    }

    private class Action<T, Q> : IReadonlyGraphStrongComponentsWith<Q>
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
    {
      private readonly T System;
      private readonly ITempFileFactory myFolderInfo;

      public Action(T system, ITempFileFactory folderInfo)
      {
        System = system;
        myFolderInfo = folderInfo;
      }

      public IEnumerable<IGnuplotPointsFile> Result { get; private set; }

      public void With<TNode>(IReadonlyGraphStrongComponents<Q, TNode> comps) where TNode : class, INode<Q>
      {
        var files = new Dictionary<IStrongComponentInfo, GnuplotPointsFileWriter>();
        GnuplotPointsFileWriter otherFilesWriter = null;

        int components = 0;
        var data = new double[System.Dimension];

        var componentIds = new List<IStrongComponentInfo>(comps.Components);
        componentIds.Sort((c1, c2) => -c1.NodesCount.CompareTo(c2.NodesCount));


        var bigerComps = new HashSet<IStrongComponentInfo>(componentIds.Take(COMPONENTS_TO_SHOW));

        var accessor = comps.Accessor(componentIds);
        foreach (var node in accessor.GetNodes())
        {
          var info = comps.Find(node);
          if (info == null)
            continue;

          GnuplotPointsFileWriter fw;
          if (bigerComps.Contains(info))
          {
            if (!files.TryGetValue(info, out fw))
            {
              fw = new GnuplotPointsFileWriter(myFolderInfo, "chain-recurrent-picture-" + ++components + ".data", System.Dimension);
              files[info] = fw;
            }
          }
          else
          {
            if (otherFilesWriter == null)
              otherFilesWriter = new GnuplotPointsFileWriter(myFolderInfo, "chain-recurrent-picture-other",
                                                             System.Dimension);
            fw = otherFilesWriter;
          }

          System.CenterPoint(node.Coordinate, data);
          fw.WritePoint(new ImagePoint(data));
        }

        var result = componentIds.Where(files.ContainsKey).Select(x => files[x]);
        if (otherFilesWriter != null)
          result = otherFilesWriter.Enum().Join(result);

        Result = result.Select(x => x.CloseFile());
      }
    }
  }  
}