using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  //TODO: Drop T
  public interface ILoopIteratorCallback<in T, N> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    void OnLoopFound(IEnumerable<N> loop, int length);
  }
}