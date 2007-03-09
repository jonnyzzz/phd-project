/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System.Collections.Generic;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateSystemConverter<TFrom, TTo>
    where TFrom : ICellCoordinate<TFrom>
    where TTo : ICellCoordinate<TTo>
  {
    ICellCoordinateSystem<TFrom> FromSystem { get; }
    ICellCoordinateSystem<TTo> ToSystem { get; }
    long[] Division { get; }

    IEnumerable<TTo> Subdivide(TFrom coordinate);
  }
}