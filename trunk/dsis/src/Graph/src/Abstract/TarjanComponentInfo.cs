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

    #region IStrongComponentInfo Members

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    #endregion

    public uint ComponentId
    {
      get { return myComponentId; }
    }

    internal void SetNodeComponent<TCell>(TarjanNode<TCell> node) 
      where TCell : ICellCoordinate
    {
      ((Node) node).SetComponentId(myComponentId);

      myNodesCount++;
    }


    public override string ToString()
    {
      return "StrongComponent: Id = " + myComponentId;
    }
  }
}