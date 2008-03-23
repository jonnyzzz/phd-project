using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface INodeSet<TNode, TCell> : INodeCollection<TNode, TCell>
    where TCell : ICellCoordinate 
    where TNode : Node<TNode, TCell>
  {
    bool AddIfNotReplace(ref TNode t);    
  }
}