using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

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
      private readonly int myLimit = 100;
      private int myCount = 0;

      public override SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to)
      {
        return new SearchTreeNode<T>(null, to);
      }

      public override bool Contains(SearchTreeNode<T> node)
      {
        return myCount > myLimit || base.Contains(node);
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