/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinate<T> : IComparable<T> where T : ICellCoordinate<T>
  {
    bool Equals(T coord);
    int GetHashCode();
  }
}