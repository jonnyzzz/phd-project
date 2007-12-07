using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public interface IVisitedCollection<T> where T : ICellCoordinate<T>
  {
    bool Contains(SearchTreeNode<T> node);
    bool IsInTree(SearchTreeNode<T> from, INode<T> to);
    SearchTreeNode<T> CreateQueuedNodeIfNoLoop(SearchTreeNode<T> parent, INode<T> to);
    void Visited(SearchTreeNode<T> node);

    void Clear();
  }
}