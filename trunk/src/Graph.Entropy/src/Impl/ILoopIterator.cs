using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Entropy.Impl
{
  public interface ILoopIterator<T> where T : ICellCoordinate<T>
  {
    void WidthSearch(IProgressInfo info);
  }
}