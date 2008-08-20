using System;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class CellProcessorContext<TFrom, TTo> : CellProcessorContextBase<TFrom, TTo>
    where TTo : ICellCoordinate
    where TFrom : ICellCoordinate
  {
    public CellProcessorContext(ICellCoordinateCollection<TFrom> countEnumerable,
                                ICellCoordinateSystemConverter<TFrom, TTo> converter,
                                ICellImageBuilder<TTo> cellImageBuilder,
                                CellImageBuilderContext<TTo> cellImageBuilderContext)
      : base(countEnumerable, converter, cellImageBuilder, cellImageBuilderContext)
    {
    }

    public CellProcessorContext<TFrom, TTo> CreateNextContext(
      ICellCoordinateCollection<TFrom> input,
      ICellCoordinateSystemConverter<TFrom, TTo> converter,
      ICellConnectionBuilder<TTo> builder
      )
    {
      return new CellProcessorContext<TFrom, TTo>(
        input,
        converter,
        CellImageBuilder,
        CellImageBuilderContext.NextStep(converter.ToSystem, builder)
        );
    }
  }
}