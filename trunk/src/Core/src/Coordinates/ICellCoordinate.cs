/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
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