namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public interface IVisitedCollection<N> 
  {
    bool Contains(SearchTreeNode<N> node);
    bool IsInTree(SearchTreeNode<N> from, N to);
    SearchTreeNode<N> CreateQueuedNodeIfNoLoop(SearchTreeNode<N> parent, N to);
    void Visited(SearchTreeNode<N> node);

    void Clear();
  }
}