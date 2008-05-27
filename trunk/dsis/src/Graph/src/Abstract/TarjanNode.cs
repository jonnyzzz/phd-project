using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    private uint myFlags = 0;
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

    public bool IsSelfLoop
    {
      get { return GetFlag(TarjanNodeFlags.IS_LOOP); }
    }

    public void SetFlag(TarjanNodeFlags mask, bool value)
    {
      if (value)
      {
        myFlags |= (uint) mask;
      }
      else
      {
        myFlags &= ~(uint) mask;
      }
    }

    public bool GetFlag(TarjanNodeFlags mask)
    {
      return (myFlags & (uint) mask) == (uint) mask;
    }

    public uint ComponentId
    {
      get { return myFlags & (uint)TarjanNodeFlags._MASK; }
    }

    public void SetComponentId(uint componentId)
    {
      myFlags = (componentId & (uint)TarjanNodeFlags._MASK) +
                  (myFlags & ~(uint)TarjanNodeFlags._MASK);
    }
  }  
}