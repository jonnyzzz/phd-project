using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanComponentInfo : IStrongComponentInfo
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

    internal void SetNodeComponent<TCell, TNode>(TNode node)
      where TCell : ICellCoordinate
      where TNode : Node<TNode, TCell>
    {
      node.SetComponentId(myComponentId);
      myNodesCount++;
    }

    public override string ToString()
    {
      return "StrongComponent: Id = " + myComponentId;
    }
  }
}