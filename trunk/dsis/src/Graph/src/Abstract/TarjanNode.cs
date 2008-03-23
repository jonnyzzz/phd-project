using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell>
    where TCell : ICellCoordinate
  {
    internal readonly TarjanNodeData<TCell> Data;
    private uint myFlags = 0;

    public TarjanNode(TCell coordinate) : base(coordinate)
    {
      Data = new TarjanNodeData<TCell>(this);
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
      get { return myFlags & (uint) TarjanNodeFlags._MASK; }
      set
      {
        myFlags = (value & (uint) TarjanNodeFlags._MASK) +
                  (myFlags & ~(uint) TarjanNodeFlags._MASK);
      }
    }
  }  
}