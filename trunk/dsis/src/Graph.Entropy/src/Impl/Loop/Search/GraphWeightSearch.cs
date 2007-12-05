using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearch<T> : GraphWeightSearchBase<T> where T : ICellCoordinate<T>
  {
    public GraphWeightSearch(IGraphStrongComponents<T> components,
                             IStrongComponentInfo component) : base(components, component)
    {
    }

    protected override IVisitedCollection CreateVisitedCollection()
    {
      return new VisitedCollection();
    }

    private class VisitedCollection : VisitedCollectionBase
    {
      public override SearchTreeNode CreateQueuedNodeIfNoLoop(SearchTreeNode parent, INode<T> to)
      {
        return new SearchTreeNode(null, to);
      }
    }
  }
}