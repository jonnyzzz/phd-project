namespace DSIS.Scheme.Impl
{
  public class SimpleComputationResult
  {
    public readonly int NodesCount;
    public readonly int EdgesCount;
    public readonly int ComponentCount;
    public readonly int NodesInComponentCount;

    public SimpleComputationResult(int nodesCount, int edgesCount, int componentCount, int nodesInComponentCount)
    {
      NodesCount = nodesCount;
      EdgesCount = edgesCount;
      ComponentCount = componentCount;
      NodesInComponentCount = nodesInComponentCount;
    }
  }
}