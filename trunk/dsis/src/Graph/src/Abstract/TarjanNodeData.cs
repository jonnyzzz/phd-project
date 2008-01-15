using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class TarjanNodeData<TCell> 
    where TCell : ICellCoordinate
  {
    public long Label = 0;
    public long Number = 0;
    private IEnumerator<TarjanNode<TCell>> myNodes = null;
    private readonly TarjanNode<TCell> myNode;

    public TarjanNodeData(TarjanNode<TCell> node)
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

    public TarjanNode<TCell> Current
    {
      get { return myNodes.Current; }
    }
  }
}