using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearch<T> : GraphWeightSearchBase<T, GraphWeightSearch<T>.VisitedCollection> 
    where T : ICellCoordinate
  {
    public GraphWeightSearch(IGraphStrongComponents<T> components,
                             IStrongComponentInfo component) : base(components, component)
    {
    }

    public sealed class VisitedCollection : VisitedCollectionBase<T>, IVisitedCollection<T>
    {
      public override SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to)
      {
        return new SearchTreeNode<T>(null, to);
      }
    }
  }     
}