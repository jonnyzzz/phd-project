using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Tarjan
{
  internal class TarjanNodeData<TCell, TNode> 
    where TCell : ICellCoordinate
    where TNode : class, INode<TCell>
  {
    public long Label;
    public long Number;
    private readonly IEnumerator<TNode> myNodes;

    public TarjanNodeData(IEnumerable<TNode> edges)
    {
      myNodes = edges.GetEnumerator();
    }

    public bool MoveNext()
    {
      return myNodes.MoveNext();
    }

    public TNode Current
    {
      get { return myNodes.Current; }
    }
  }
}