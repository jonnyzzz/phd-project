using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentGraph<TCell> :
    AbstractGraph<StrongComponentGraph<TCell>, TCell, StrongComponentNode<TCell>>,
    IGraphStrongComponents<TCell>,
    IGraphWithStrongComponent<TCell>,
    IGraphExtension<StrongComponentNode<TCell>, TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private readonly IStrongComponentInfoManager myComponents;

    public StrongComponentGraph(ICellCoordinateSystem<TCell> coordinateSystem, IStrongComponentInfoManager info)
      : base(coordinateSystem)
    {
      myComponents = info;
    }

    #region IGraphStrongComponents<TCell> Members

    public int ComponentCount
    {
      get { return myComponents.Count; }
    }

    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myComponents.Components; }
    }


    public CountEnumerable<TCell> GetCoordinates(ICollection<IStrongComponentInfo> components)
    {
      int cnt = 0;
      foreach (IStrongComponentInfo info in components)
      {
        cnt += info.NodesCount;
      }
      return new CountEnumerable<TCell>(GetCoordinatesImpl(components), cnt);
    }

    private IEnumerable<TCell> GetCoordinatesImpl(ICollection<IStrongComponentInfo> components)
    {
      foreach (INode<TCell> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node, ICollection<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, GetEdgesInternal(node));
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return GetStrongComponentInfo((StrongComponentNode<TCell>) node);
    }

    public IEnumerable<INode<TCell>> GetNodes(ICollection<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, NodesInternal);
    }

    #endregion

    #region IGraphWithStrongComponent<TCell> Members

    public IGraphStrongComponents<TCell> ComputeStrongComponents(IProgressInfo info)
    {
      return this;
    }

    public override void Dump(TextWriter tw)
    {
      base.Dump(tw);
      tw.WriteLine();
      DumpComponentsGraph(tw);
      tw.WriteLine("-----------------------------------------");
    }

    #endregion

    #region IGraphExtension<StrongComponentNode<TCell>,TCell> Members

    StrongComponentNode<TCell> IGraphExtension<StrongComponentNode<TCell>, TCell>.CreateNode(TCell coordinate)
    {
      return new StrongComponentNode<TCell>(coordinate);
    }

    void IGraphExtension<StrongComponentNode<TCell>, TCell>.EdgeAdded(StrongComponentNode<TCell> from,
                                                                      StrongComponentNode<TCell> to)
    {
      IStrongComponentInfoEx fromInfo = GetStrongComponentInfo(from);
      IStrongComponentInfoEx toInfo = GetStrongComponentInfo(to);
      myComponents.OnConnection(fromInfo, toInfo);
    }

    void IGraphExtension<StrongComponentNode<TCell>, TCell>.NodeAdded(StrongComponentNode<TCell> node)
    {
      GetStrongComponentInfo(node);
    }

    #endregion

    private IStrongComponentInfoEx GetStrongComponentInfo(StrongComponentNode<TCell> node)
    {
      IStrongComponentInfoEx info = node.StrongComponent;
      if (info == null)
      {
        info = (IStrongComponentInfoEx) myComponents.CreateComponentInfo();
        info.NodesCount++;
        node.StrongComponent = info;
        myComponents.AddComponent(info);
      }
      return info;
    }

    internal static IEnumerable<IStrongComponentInfoEx> Optimize(IEnumerable<IStrongComponentInfo> infos)
    {
      Hashset<IStrongComponentInfoEx> result = new Hashset<IStrongComponentInfoEx>();
      foreach (IStrongComponentInfoEx info in infos)
      {
        result.Add(info.Reference);
      }
      return result.Values;
    }

    private void DumpComponentsGraph(TextWriter tw)
    {
      Dictionary<IStrongComponentInfo, int> ids = new Dictionary<IStrongComponentInfo, int>();
      int cnt = 0;
      tw.WriteLine("Components:[ Count =  {0} ]", ComponentCount);
      foreach (IStrongComponentInfoEx info in Optimize(myComponents.Components))
      {
        int id;
        if (!ids.TryGetValue(info, out id))
        {
          id = ++cnt;
          ids[info] = id;
        }

        tw.Write("  {0} -> {{", id);

        info.Dump(tw, ids, ref cnt);

        tw.WriteLine("}}");
      }
      tw.WriteLine("Finished \r\n");
    }
  }
}