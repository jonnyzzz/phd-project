using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public interface ILoopIteratorCallback<in T> 
    where T:ICellCoordinate
  {
    void OnLoopFound(IEnumerable<INode<T>> loop, int length);
  }
}