using DSIS.Core.Coordinates;

namespace DSIS.Graph.FS
{
  public class FSReadonlyNode<TCell> : INode<TCell>
    where TCell : ICellCoordinate
  {
    private readonly TCell myCoordinate;

    public IndexEntry Entry { get; set; }

    public FSReadonlyNode(TCell coordinate)
    {
      myCoordinate = coordinate;
    }

    public TCell Coordinate
    {
      get { return myCoordinate; }
    }

    public uint ComponentId { get; set;}

    public bool IsSelfLoop { get; set; }
  }
}