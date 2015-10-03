using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public interface ILoopIterator
  {
    void WidthSearch();
  }

  [Obsolete]
  public interface ILoopIterator<T> where T : ICellCoordinate
  {
  }
}