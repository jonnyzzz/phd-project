using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class GraphNodeHashListSetState<TNode, TCell> : GraphNodeHashList<TNode, TCell>, INodeSetState<TNode, TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    public GraphNodeHashListSetState(int capacity) : base(capacity)
    {
    }

    public GraphNodeHashListSetState(int capacity, TNode node, params TNode[] nodes) : base(capacity, node, nodes)
    {
    }

    public INodeSetState<TNode, TCell> AddIfNotReplace(ref TNode t, out bool wasAdded)
    {
      var found = Find(t.Coordinate);

      if (wasAdded = (found == null))
      {
        AddNodeNoCheck(t);
      } else
      {
        t = found;
      }
      return this;
    }
  }
}