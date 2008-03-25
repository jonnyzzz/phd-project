using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    private uint myFlags = 0;

    public TarjanNode(TCell coordinate) : base(coordinate)
    {      
    }

    internal TarjanNodeData<TCell> Data
    {
      get
      {
        if (!HasUserData)
        {
          SetUserData(new TarjanNodeData<TCell>(this));
        }
        return GetUserData<TarjanNodeData<TCell>>();
      }
    }

    internal void ClearNodeData()
    {
      SetUserData<TarjanNodeData<TCell>>(null);
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