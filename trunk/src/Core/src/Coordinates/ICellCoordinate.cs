/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System.Collections.Generic;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinate<T> where T : ICellCoordinate<T>
  {
    IEqualityComparer<T> Comparer { get; }
  }
}