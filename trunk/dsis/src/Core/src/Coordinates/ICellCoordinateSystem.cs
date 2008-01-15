/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using DSIS.Core.System;
using DSIS.Core.Util;

namespace DSIS.Core.Coordinates
{
  public interface ICellCoordinateSystem
  {
    long[] Subdivision { get; }
    ISystemSpace SystemSpace { get; }

    int Dimension { get;}
  }

  /// <summary>
  /// Basic notion of CellCoordinate System. Custom system features to be defined in
  /// it's specific interface.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface ICellCoordinateSystem<T> : ICellCoordinateSystem
    where T : ICellCoordinate
  {
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

    ICellCoordinateSystemProjector<T> Project(long[] factor);

    /// <summary>
    /// Returns all cells for initial space provided by ISystemSpace
    /// </summary>
    CountEnumerable<T> InitialSubdivision { get; }
  }
}