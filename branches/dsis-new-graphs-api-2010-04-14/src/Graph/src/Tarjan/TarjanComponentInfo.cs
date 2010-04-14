using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Tarjan
{
  public class TarjanComponentInfo : IStrongComponentInfo, IEquatable<TarjanComponentInfo>
  {
    private int myNodesCount = 0;
    private readonly uint myComponentId;

    public TarjanComponentInfo(int nodesCount, uint componentId)
    {
      myNodesCount = nodesCount;
      myComponentId = componentId;
    }

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    public uint ComponentId
    {
      get { return myComponentId; }
    }

    internal void SetNodeComponent<TCell, TNode>(IGraphDataHolder<uint, TNode> componentIdHolder, TNode node)
      where TCell : ICellCoordinate
      where TNode : class, INode<TCell>
    {
      componentIdHolder.SetData(node, myComponentId);
      myNodesCount++;
    }

    public override string ToString()
    {
      return "StrongComponent: Id = " + myComponentId;
    }

    public bool Equals(TarjanComponentInfo obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.myComponentId == myComponentId;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (TarjanComponentInfo)) return false;
      return Equals((TarjanComponentInfo) obj);
    }

    public override int GetHashCode()
    {
      return myComponentId.GetHashCode();
    }
  }
}