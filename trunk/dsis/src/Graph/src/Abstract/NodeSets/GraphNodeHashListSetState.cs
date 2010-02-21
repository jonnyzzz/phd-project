using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract.NodeSets
{
  public class GraphNodeHashListSetState<TNode, TCell> : GraphNodeHashList<TNode, TCell>, INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    public GraphNodeHashListSetState(int capacity, TNode node, params TNode[] nodes) : base(capacity, node, nodes)
    {
    }

    public INodeSetState<TNode, TCell> AddIfNotReplace(TNode t, out bool wasAdded)
    {
      wasAdded = !Contains(t);      
      if (wasAdded)
      {
        AddNodeNoCheck(t);
      }
      return this;
    }
  }
}