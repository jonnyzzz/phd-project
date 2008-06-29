using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanComponentInfoManager
  {
    private uint myIndex = 0;
    private readonly Dictionary<uint, IStrongComponentInfo> myInfos 
      = new Dictionary<uint, IStrongComponentInfo>();

    public TarjanComponentInfo NextComponent()
    {
      var info = new TarjanComponentInfo(0, ++myIndex);
      myInfos[info.ComponentId] = info;
      return info;
    }

    public int Count
    {
      get { return myInfos.Count; }
    }

    public IStrongComponentInfo FindByNode<T>(INode<T> node) 
      where T : ICellCoordinate
    {
      IStrongComponentInfo info;
      return myInfos.TryGetValue(node.ComponentId, out info) ? info : null;
    }

    public IEnumerable<IStrongComponentInfo> Infos
    {
      get { return myInfos.Values; }
    }
  }
}