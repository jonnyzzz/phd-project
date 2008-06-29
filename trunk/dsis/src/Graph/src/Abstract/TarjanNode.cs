using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    private readonly Lazy<TarjanNodeData<TCell>> myLazyTarjanNodeData;

    public TarjanNode(TCell coordinate) : base(coordinate)
    {
      myLazyTarjanNodeData = () => new TarjanNodeData<TCell>(this);
    }
    
    internal TarjanNodeData<TCell> Data
    {
      get { return GetUserData(myLazyTarjanNodeData); }
    }

    internal void ClearNodeData()
    {
      SetUserData<TarjanNodeData<TCell>>(null);
    }
  }  
}