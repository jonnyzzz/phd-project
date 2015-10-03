using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal interface INodeInternal<TCell> 
    where TCell : ICellCoordinate
  {
    IEnumerable<INode<TCell>> Edges{ get; }
  }
}