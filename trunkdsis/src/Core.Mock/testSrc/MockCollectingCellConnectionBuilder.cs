using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;

namespace DSIS.Core.Mock
{
  public class MockCollectingCellConnectionBuilder<T> : ICellConnectionBuilder<T> where T : ICellCoordinate<T>
  {
    private List<T> myResult = new List<T>();

    public void ConnectToMany(T cell, IEnumerable<T> v)
    {
      myResult.AddRange(v);
    }

    public void ConnectToOne(T cell, T v)
    {
      myResult.Add(v);
    }

    public List<T> Result
    {
      get { return myResult; }
    }
  }
}