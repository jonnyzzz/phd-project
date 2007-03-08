/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using DSIS.Core.System;
using DSIS.Core.Util;

namespace DSIS.Core.Coordinates
{
  /// <summary>
  /// Basic notion of CellCoordinate System. Custom system features to be defined in
  /// it's specific interface.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ICellCoordinateSystem<T> where T : ICellCoordinate<T>
  {
    long[] Subdivision { get; }

    /// <summary>
    /// Return ICellCoordinate for point.
    /// If point is outside of space <code>null</code> is returned
    /// </summary>
    /// <param name="point">array with length of <code>SystemSpace.Dimension</code></param>
    /// <returns>ICellCoordinate or null</returns>
    [Nullable]
    T FromPoint(double[] point);


    /// <summary>
    /// This interface is intended to be used to perform 
    /// subdivision of cell coordinates
    /// </summary>
    /// <param name="division"></param>
    /// <returns></returns>
    ICellCoordinateSystemConverter<T, T> Subdivide(long[] division);

    /// <summary>
    /// Returns all cells for initial space provided by ISystemSpace
    /// </summary>
    CountEnumerable<T> InitialSubdivision { get; }

    long InitialCellsCount { get; }


    ISystemSpace SystemSpace { get; }
  }
}