using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public interface IGraphWeightSearch<T> where T : ICellCoordinate<T>
  {
    void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> anode);
  }
}