using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  public class CellConnectionBuilder<Q> : ICellConnectionBuilder<Q>
    where Q : IIntegerCoordinate    
  {
    private readonly List<Pair<Q, Q[]>> myResult = new List<Pair<Q, Q[]>>();

    public void ConnectToOne(Q cell, Q v)
    {
      myResult.Add(Pair.Of(cell, new[] {v}));
    }

    public void ConnectToMany(Q cell, IEnumerable<Q> v)
    {
      myResult.Add(Pair.Of(cell, v.ToArray()));
    }

    public IEnumerable<Pair<Q, Q[]>> Result
    {
      get { return myResult; }
    }

    public void Clear()
    {
      myResult.Clear();
    }
  }
}