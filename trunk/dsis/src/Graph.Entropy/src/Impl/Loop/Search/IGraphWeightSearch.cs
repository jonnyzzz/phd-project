using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Search
{
  public interface IGraphWeightSearch<T> 
    where T : ICellCoordinate
  {
    void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode);
  }
}