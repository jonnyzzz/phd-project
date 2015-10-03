using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearchLimited<T> : GraphWeightSearchBase<T, GraphWeightSearchLimited<T>.VisitedCollection>
    where T : ICellCoordinate
  {
    public GraphWeightSearchLimited(IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(components, component)
    {
    }

    public sealed class VisitedCollection : VisitedCollectionBase<T>
    {
      private const int LIMIT = 1000;
      private int myCount;

      public override SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to)
      {
        return new SearchTreeNode<T>(null, to);
      }

      public override bool Contains(SearchTreeNode<T> node)
      {
        return myCount > LIMIT || base.Contains(node);
      }

      public override void Visited(SearchTreeNode<T> node)
      {
        myCount++;
        base.Visited(node);
      }

      public override void Clear()
      {
        myCount = 0;
        base.Clear();
      }
    }
  }
}