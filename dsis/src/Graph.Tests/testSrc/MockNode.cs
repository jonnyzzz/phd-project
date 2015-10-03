using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Tests
{
  public class MockNode<T> : INode<T> where T : ICellCoordinate
  {
    private readonly T myCoordinate;

    public MockNode(T coordinate)
    {
      myCoordinate = coordinate;
    }

    public T Coordinate
    {
      get { return myCoordinate; }
    }

    public void SetUserData<T1>(T1 data)
    {
      throw new System.NotImplementedException();
    }

    public T1 GetUserData<T1>(Lazy<T1> def)
    {
      throw new System.NotImplementedException();
    }

    public bool HasUserData<T1>()
    {
      throw new System.NotImplementedException();
    }
  }
}