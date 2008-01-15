using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  /// <summary>
  /// Base Interface for cell Image Builder settings. 
  /// No common parameters. Used as the base interface 
  /// for the hierarchy
  /// </summary>
  public interface ICellImageBuilderIntegerCoordinatesSettings : ICellImageBuilderSettings
  {
    ICellImageBuilder<TCell> Create<TSys, TCell>()
      where TSys : IIntegerCoordinateSystem<TCell>
      where TCell : IIntegerCoordinate;
  }
}