using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public abstract class NodeSetBase<TNode, TCell> : INodeCollection<TNode,TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    public abstract IEnumerable<TNode> Values { get;}
  }
}