using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public interface IGraphWeightSearch<out T,N> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    void WidthSearch(ILoopIteratorCallback<T,N> callback, N anode);
  }
}