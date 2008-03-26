using DSIS.Core.Builders;
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
    ICellImageBuilder<TCell> Create<TCell>()
      where TCell : IIntegerCoordinate;
  }
}