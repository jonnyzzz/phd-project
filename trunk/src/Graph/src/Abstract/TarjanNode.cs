using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class TarjanNode<TCell> : Node<TarjanNode<TCell>, TCell> 
    where TCell : ICellCoordinate<TCell>
  {
    private TarjanNodeData<TCell> myData = null;
    private uint myFlags = 0;

    public void SetFlag(TarjanNodeFlags mask, bool value)
    {
      if (value)
      {
        myFlags |= (uint)mask;
      } else
      {
        myFlags &= ~(uint)mask;
      }
    }

    public bool GetFlag(TarjanNodeFlags mask)
    {
      return (myFlags & (uint)mask) == (uint)mask;
    }

    public TarjanNode(TCell coordinate) : base(coordinate)
    {
    }

    internal TarjanNodeData<TCell> Data
    {
      get
      {
        if (myData == null)
          myData = new TarjanNodeData<TCell>(EdgesInternal);

        return myData;
      }
      set { myData = value; }
    }

    public uint ComponentId
    {
      get
      {
        return  myFlags & (uint)TarjanNodeFlags._MASK;
      }
      set 
      { 
        myFlags = (value & (uint)TarjanNodeFlags._MASK) + 
                  (myFlags & ~(uint)TarjanNodeFlags._MASK); 
      }
    }
  }
}