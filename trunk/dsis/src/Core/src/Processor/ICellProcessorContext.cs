using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public interface ICellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate<TTo>
    where TFrom : ICellCoordinate<TFrom>
  {
    ICountEnumerable<TFrom> Cells { get; }

    ICellCoordinateSystemConverter<TFrom, TTo> Converter { get; }

    ICellImageBuilder<TTo> CellImageBuilder { get; }

    CellImageBuilderContext<TTo> CellImageBuilderContext { get; }    
  }

  public interface ICellProcessorMultiplyContext<T> : ICellProcessorContext<T,T> 
    where T : ICellCoordinate<T>
  {
    long[] Division { get; }
  }
}