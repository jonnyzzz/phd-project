using System.Collections.Generic;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public abstract class VisitedCollectionBase<N> : IVisitedCollection<N> 
  {
    protected readonly IEqualityComparer<N> myCmp;
    private readonly HashSet<N> myVisited;

    public VisitedCollectionBase(IEqualityComparer<N> cmp)
    {
      myCmp = cmp;
      myVisited = new HashSet<N>(cmp);
    }

    public virtual bool Contains(SearchTreeNode<N> node)
    {
      return myVisited.Contains(node.Node);
    }    

    public virtual bool IsInTree(SearchTreeNode<N> from, N to)
    {
      return myVisited.Contains(to);
    }

    public abstract SearchTreeNode<N> CreateQueuedNodeIfNoLoop(SearchTreeNode<N> parent, N to);

    public virtual void Visited(SearchTreeNode<N> node)
    {
      myVisited.Add(node.Node);
    }

    public virtual void Clear()
    {
      myVisited.Clear();
    }
  }
}