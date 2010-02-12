using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  internal interface INodeInternal<out TCell> 
    where TCell : ICellCoordinate
  {
    IEnumerable<INode<TCell>> Edges{ get; }
    uint ComponentId { get; }
  }
}