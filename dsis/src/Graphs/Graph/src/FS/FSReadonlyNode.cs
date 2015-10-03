using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  [EqualityComparer(typeof(FSReadonlyNodeComparer<>))]
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