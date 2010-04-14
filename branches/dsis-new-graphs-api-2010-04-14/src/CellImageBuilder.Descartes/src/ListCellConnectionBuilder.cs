using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  [Used]
  public class ListCellConnectionBuilder<Q> : ICellConnectionBuilder<Q>
    where Q : ICellCoordinate
  {
    private readonly MultiDictionary<Q, Q> myPoints = new MultiDictionary<Q, Q>(EqualityComparerFactory<Q>.GetComparer());

    public void ConnectToOne(Q cell, Q v)
    {
      myPoints.AddValue(cell, v);
    }

    public void ConnectToMany(Q cell, IEnumerable<Q> v)
    {
      myPoints.AddValues(cell, v);
    }

    public IEnumerable<KeyValuePair<Q, List<Q>>> Values
    {
      get { return myPoints; }
    }

    public bool IsEmpty
    {
      get { return myPoints.Count == 0; }
    }

    [Used]
    public void Clear()
    {
      myPoints.Clear();
    }
  }
}