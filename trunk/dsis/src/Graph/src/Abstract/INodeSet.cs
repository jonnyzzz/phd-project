using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface INodeSet<TNode, TCell> : INodeCollection<TNode, TCell>
    where TCell : ICellCoordinate 
    where TNode : Node<TNode, TCell>
  {
    TNode AddIfNotReplace(TCell cell, IGraphNodeFactory<TNode, TCell> ext, out bool wasAdded);

    bool Contains(TCell node);

    TNode Find(TCell node);
  }
}