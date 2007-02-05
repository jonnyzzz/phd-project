using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentGraph<TCell> : 
    AbstractGraph<TCell, StrongComponentNode<TCell>>, 
    IGraphStrongComponents<TCell>,
    IGraphWithStrongComponent<TCell>
    where TCell : ICellCoordinate<TCell>
  {
    private IStrongComponentInfoManager myComponents;

    public StrongComponentGraph(ICellCoordinateSystem<TCell> coordinateSystem, IStrongComponentInfoManager info) : base(coordinateSystem)
    {
      myComponents = info;
    }
    
    public int ComponentCount
    {
      get { return myComponents.Count; }
    }


    public IEnumerable<IStrongComponentInfo> Components
    {
      get { return myComponents.Components; }
    }

    protected override StrongComponentNode<TCell> CreateNode(TCell coordinate)
    {
      return new StrongComponentNode<TCell>(coordinate);
    }

    protected override void NodeAdded(StrongComponentNode<TCell> node)
    {
      base.NodeAdded(node);

      GetStrongComponentInfo(node);
    }

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

    protected override void EdgeAdded(StrongComponentNode<TCell> from,
                                      StrongComponentNode<TCell> to)
    {
      base.EdgeAdded(from, to);

      IStrongComponentInfoEx fromInfo = GetStrongComponentInfo(from);
      IStrongComponentInfoEx toInfo = GetStrongComponentInfo(to);
      myComponents.OnConnection(fromInfo, toInfo);
    }

    public IEnumerable<INode<TCell>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, NodesInternal);
    }

    public IEnumerable<INode<TCell>> GetEdgesWithFilteredEdges(INode<TCell> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, GetEdgesInternal(node));
    }

    public IEnumerable<TCell> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      foreach (INode<TCell> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
    }

    public IStrongComponentInfo GetNodeComponent(INode<TCell> node)
    {
      return GetStrongComponentInfo((StrongComponentNode<TCell>) node);
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


    public override void Dump(TextWriter tw)
    {
      base.Dump(tw);
      tw.WriteLine();
      DumpComponentsGraph(tw);
      tw.WriteLine("-----------------------------------------");
    }

    public IGraphStrongComponents<TCell> ComputeStrongComponents(IProgressInfo info)
    {
      return this;
    }
  }
}