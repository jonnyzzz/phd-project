using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl
{
  public interface IGraphWeightSearchCallback<T> where T:ICellCoordinate<T>
  {
    void OnLoopFound(IList<INode<T>> loop);
  }
}