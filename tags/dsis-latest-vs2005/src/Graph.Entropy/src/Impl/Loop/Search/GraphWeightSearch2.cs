using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public class GraphWeightSearch2<T> : GraphWeightSearchBase<T, GraphWeightSearch2<T>.VisitedCollection> 
    where T : ICellCoordinate
  {
    public GraphWeightSearch2(IGraphStrongComponents<T> components,
                              IStrongComponentInfo component) : base(components, component)
    {
    }

    public sealed class VisitedCollection : VisitedCollectionBase<T>, IVisitedCollection<T>
    {
      public override SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to)
      {
        return parent.Child(to);
      }
    }    
  }
}