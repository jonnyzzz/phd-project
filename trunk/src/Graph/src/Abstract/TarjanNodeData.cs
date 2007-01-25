using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class TarjanNodeData<TCell, TValue> where TCell : ICellCoordinate<TCell>
  {
    public int Label = 0;
    public int Number = 0;
    private IEnumerator<TarjanNode<TCell, TValue>> myNodes;

    public TarjanNodeData(IEnumerable<TarjanNode<TCell, TValue>> nodes)
    {
      myNodes = nodes.GetEnumerator();
    }

    public bool MoveNext()
    {
      return myNodes.MoveNext();
    }

    public TarjanNode<TCell, TValue> Current
    {
      get { return myNodes.Current; }
    }
  }
}