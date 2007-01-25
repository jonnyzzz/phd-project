using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentGraph<TCell, TValue> : 
    AbstractGraph<TCell, StrongComponentNode<TCell, TValue>, TValue>, 
    IGraphStrongComponents<TCell, TValue>,
    IGraphWithStrongComponent<TCell, TValue>
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

    protected override StrongComponentNode<TCell, TValue> CreateNode(TCell coordinate)
    {
      return new StrongComponentNode<TCell, TValue>(coordinate, default(TValue));
    }

    protected override void NodeAdded(StrongComponentNode<TCell, TValue> node)
    {
      base.NodeAdded(node);

      GetStrongComponentInfo(node);
    }

    private IStrongComponentInfoEx GetStrongComponentInfo(StrongComponentNode<TCell, TValue> node)
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

    protected override void EdgeAdded(StrongComponentNode<TCell, TValue> from,
                                      StrongComponentNode<TCell, TValue> to)
    {
      base.EdgeAdded(from, to);

      IStrongComponentInfoEx fromInfo = GetStrongComponentInfo(from);
      IStrongComponentInfoEx toInfo = GetStrongComponentInfo(to);
      myComponents.OnConnection(fromInfo, toInfo);
    }

    public IEnumerable<INode<TCell, TValue>> GetNodes(IEnumerable<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, NodesInternal);
    }

    public IEnumerable<INode<TCell, TValue>> GetEdgesWithFilteredEdges(INode<TCell, TValue> node, IEnumerable<IStrongComponentInfo> componentIds)
    {
      return myComponents.FilterNodes(componentIds, GetEdgesInternal(node));
    }

    public IEnumerable<TCell> GetCoordinates(IEnumerable<IStrongComponentInfo> components)
    {
      foreach (INode<TCell, TValue> node in GetNodes(components))
      {
        yield return node.Coordinate;
      }
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

    public IGraphStrongComponents<TCell, TValue> ComputeStrongComponents(IProgressInfo info)
    {
      return this;
    }
  }
}