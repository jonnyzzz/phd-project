using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal class TarjanNodeData<TCell> where TCell : ICellCoordinate<TCell>
  {
    public int Label = 0;
    public int Number = 0;
    private IEnumerator<TarjanNode<TCell>> myNodes;

    public TarjanNodeData(IEnumerable<TarjanNode<TCell>> nodes)
    {
      myNodes = nodes.GetEnumerator();
    }

    public bool MoveNext()
    {
      return myNodes.MoveNext();
    }

    public TarjanNode<TCell> Current
    {
      get { return myNodes.Current; }
    }
  }
}