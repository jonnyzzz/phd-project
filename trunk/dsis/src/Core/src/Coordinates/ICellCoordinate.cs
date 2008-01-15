/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System;

namespace DSIS.Core.Coordinates
{
  /// <summary>
  /// Marker interface for cell coordinate implementation. 
  /// This implementation depends on the coordinate system class
  /// </summary>
  public interface ICellCoordinate
  {    
  }

  [Obsolete("Use ICellCoordinate instead")]
  public interface ICellCoordinate<T> : ICellCoordinate
    where T : ICellCoordinate<T>
  {    
  }
}