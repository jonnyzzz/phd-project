using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BexMethodTest
{
  public class MockCellConnectionManager<T> : ICellConnectionBuilder<T> where T:ICellCoordinate<T>
  {
    private List<T> myResult = new List<T>();

    public void ConnectToOne(T cell, T v)
    {
      myResult.Add(v);
    }

    public void ConnectToMany(T cell, IEnumerable<T> v)
    {
      myResult.AddRange(v);
    }

    public List<T> Result
    {
      get { return myResult; }
    }
  }
}