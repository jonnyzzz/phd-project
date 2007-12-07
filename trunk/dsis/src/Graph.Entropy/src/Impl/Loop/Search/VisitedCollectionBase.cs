using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public abstract class VisitedCollectionBase<T> : IVisitedCollection<T> 
    where T : ICellCoordinate<T>
  {
    private readonly Hashset<INode<T>> myVisited =
      new Hashset<INode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());

    public virtual bool Contains(SearchTreeNode<T> node)
    {
      return myVisited.Contains(node.Node);
    }    

    public virtual bool IsInTree(SearchTreeNode<T> from, INode<T> to)
    {
      return myVisited.Contains(to);
    }

    public abstract SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to);

    public virtual void Visited(SearchTreeNode<T> node)
    {
      myVisited.Add(node.Node);
    }

    public virtual void Clear()
    {
      myVisited.Clear();
    }
  }
}