using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public struct CellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate<TTo>
    where TFrom : ICellCoordinate<TFrom>
  {
    private readonly ICellCoordinateSystemConverter<TFrom, TTo> myConverter;
    private readonly CountEnumerable<TFrom> myCountEnumerable;
    private readonly ICellImageBuilder<TTo> myCellImageBuilder;
    private readonly CellImageBuilderContext<TTo> myCellImageBuilderContext;

    public CellProcessorContext(long cellsCount, IEnumerable<TFrom> cells,
                                ICellCoordinateSystemConverter<TFrom, TTo> converter,
                                ICellImageBuilder<TTo> cellImageBuilder,
                                CellImageBuilderContext<TTo> cellImageBuilderContext)
    {
      myConverter = converter;
      myCountEnumerable = new CountEnumerable<TFrom>(cells, cellsCount);
      myCellImageBuilder = cellImageBuilder;
      myCellImageBuilderContext = cellImageBuilderContext;
    }


    public CellProcessorContext(
      CountEnumerable<TFrom> countEnumerable,
      ICellCoordinateSystemConverter<TFrom, TTo> converter,
      ICellImageBuilder<TTo> cellImageBuilder,
      CellImageBuilderContext<TTo> cellImageBuilderContext)
    {
      myConverter = converter;
      myCountEnumerable = countEnumerable;
      myCellImageBuilder = cellImageBuilder;
      myCellImageBuilderContext = cellImageBuilderContext;
    }

    public CountEnumerable<TFrom> Cells
    {
      get { return myCountEnumerable; }
    }

    public ICellCoordinateSystemConverter<TFrom, TTo> Converter
    {
      get { return myConverter; }
    }

    public ICellImageBuilder<TTo> CellImageBuilder
    {
      get { return myCellImageBuilder; }
    }

    public CellImageBuilderContext<TTo> CellImageBuilderContext
    {
      get { return myCellImageBuilderContext; }
    }

    public CellProcessorContext<TFrom, TTo> CreateNextContext(
      CountEnumerable<TFrom> input,
      ICellCoordinateSystemConverter<TFrom, TTo> converter,
      ICellConnectionBuilder<TTo> builder
      )
    {
      return new CellProcessorContext<TFrom, TTo>(
        input.Count,
        input,
        converter,
        CellImageBuilder,
        new CellImageBuilderContext<TTo>(
          CellImageBuilderContext.Function,
          CellImageBuilderContext.Settings,
          converter.ToSystem, builder)
        );
    }
  }
}