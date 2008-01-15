using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public interface ICellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate
    where TFrom : ICellCoordinate
  {
    ICountEnumerable<TFrom> Cells { get; }

    ICellCoordinateSystemConverter<TFrom, TTo> Converter { get; }

    ICellImageBuilder<TTo> CellImageBuilder { get; }

    CellImageBuilderContext<TTo> CellImageBuilderContext { get; }    
  }
}