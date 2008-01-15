/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
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