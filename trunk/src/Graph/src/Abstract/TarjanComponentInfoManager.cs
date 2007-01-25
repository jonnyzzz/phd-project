using System.Collections.Generic;

namespace DSIS.Graph.Abstract
{
  public class TarjanComponentInfoManager
  {
    private uint myIndex = 0;
    private List<TarjanComponentInfo> myInfos = new List<TarjanComponentInfo>();

    public TarjanComponentInfo NextComponent()
    {
      TarjanComponentInfo info = new TarjanComponentInfo(0, ++myIndex);
      myInfos.Add(info);
      return info;
    }

    public int Count
    {
      get { return myInfos.Count; }
    }

    public IEnumerable<IStrongComponentInfo> Infos
    {
      get
      {
        foreach (TarjanComponentInfo info in myInfos)
        {
          yield return info;
        }
      }
    }
  }
}