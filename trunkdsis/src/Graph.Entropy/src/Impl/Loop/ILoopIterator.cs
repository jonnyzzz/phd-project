using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public interface ILoopIterator<T> where T : ICellCoordinate<T>
  {
    void WidthSearch();
  }
}