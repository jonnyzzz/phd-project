/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using System.Collections.Generic;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateSystemConverter<TFrom, TTo>
    where TFrom : ICellCoordinate
    where TTo : ICellCoordinate
  {
    ICellCoordinateSystem<TFrom> FromSystem { get; }
    ICellCoordinateSystem<TTo> ToSystem { get; }
    
    IEnumerable<TTo> Subdivide(TFrom coordinate);

    ICellCoordinateSystemConverter<TFrom, TTo> Clone();
  }
}