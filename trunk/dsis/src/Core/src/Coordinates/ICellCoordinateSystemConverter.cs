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
    
    IEnumerable<TTo> Subdivide(TFrom coordinate);

    ICellCoordinateSystemConverter<TFrom, TTo> Clone();
  }

  public interface ICellCoordinateSystemMultiplyConverter<T> : ICellCoordinateSystemConverter<T,T> 
    where T : ICellCoordinate<T>
  {
    long[] Division { get; }
  }
}