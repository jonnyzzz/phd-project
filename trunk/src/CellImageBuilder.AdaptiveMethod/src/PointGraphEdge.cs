namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public struct PointGraphEdge
  {
    public readonly PointGraphNode Node1;
    public readonly PointGraphNode Node2;

    public PointGraphEdge(PointGraphNode node1, PointGraphNode node2)
    {
      Node1 = node1;
      Node2 = node2;
    }
  }
}