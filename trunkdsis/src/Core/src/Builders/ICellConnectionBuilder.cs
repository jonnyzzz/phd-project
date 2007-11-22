/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Core.Builders
{
  /// <summary>
  /// This interface is used as a call back from ICellImageBuilder implementor.
  /// This interface can be implemented by data structure, e.g. graph, list, etc.
  /// To separate some figure to cells please use ICellCoordinateSystem implementor
  /// object. 
  /// </summary>
  public interface ICellConnectionBuilder<TCell> where TCell : ICellCoordinate<TCell>
  {
    void ConnectToOne(TCell cell, TCell v);
    void ConnectToMany(TCell cell, IEnumerable<TCell> v);
  }
}