using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class TarjanNodeData<TCell, TNode> 
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
  {
    public long Label = 0;
    public long Number = 0;
    private IEnumerator<TNode> myNodes = null;
    private readonly TNode myNode;

    public TarjanNodeData(TNode node)
    {
      myNode = node;      
    }

    public bool MoveNext()
    {
      if (myNodes == null)
      {
        myNodes = myNode.EdgesInternal.GetEnumerator();
      }

      return myNodes.MoveNext();
    }

    public TNode Current
    {
      get { return myNodes.Current; }
    }
  }
}