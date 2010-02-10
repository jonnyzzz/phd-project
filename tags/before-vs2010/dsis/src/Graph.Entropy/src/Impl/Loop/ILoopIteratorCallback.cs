using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public interface ILoopIteratorCallback<T> 
    where T:ICellCoordinate
  {
    void OnLoopFound(IEnumerable<INode<T>> loop, int length);
  }
}