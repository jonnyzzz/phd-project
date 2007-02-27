using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public class MockNode<T> : INode<T> where T : ICellCoordinate<T>
  {
    private T myCoordinate;

    public MockNode(T coordinate)
    {
      myCoordinate = coordinate;
    }

    public T Coordinate
    {
      get { return myCoordinate; }
    }
  }
}