using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  public class CellConnectionBuilder<Q> : ICellConnectionBuilder<Q>
    where Q : IIntegerCoordinate    
  {
    private readonly List<Pair<Q, IEnumerable<Q>>> myResult = new List<Pair<Q, IEnumerable<Q>>>();

    public void ConnectToOne(Q cell, Q v)
    {
      myResult.Add(Pair.Of<Q, IEnumerable<Q>>(cell, new[] {v}));
    }

    public void ConnectToMany(Q cell, IEnumerable<Q> v)
    {
      myResult.Add(Pair.Of(cell, v));
    }

    public IEnumerable<Pair<Q, IEnumerable<Q>>> Result
    {
      get { return myResult; }
    }

    public void Clear()
    {
      myResult.Clear();
    }
  }
}