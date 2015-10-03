using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public interface INodeCollection<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    IEnumerable<TNode> Values { get;}
    IEnumerable<INode<TCell>> ValuesUpcasted { get;}
  }
}