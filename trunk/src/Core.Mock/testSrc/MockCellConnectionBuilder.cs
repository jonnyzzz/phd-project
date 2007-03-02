using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;

namespace DSIS.Core.Mock
{
  public class MockCellConnectionBuilder<TCell> : ICellConnectionBuilder<TCell> where TCell : ICellCoordinate<TCell>
  {
    public void ConnectToMany(TCell cell, IEnumerable<TCell> v)
    {
      foreach (TCell t in v)
      {
        ConnectToOne(cell, t);
      }
    }

    public void ConnectToOne(TCell cell, TCell v)
    {
    }
  }
}