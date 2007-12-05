using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public interface IGraphWeightSearch<T> where T : ICellCoordinate<T>
  {
    void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode);
  }
}