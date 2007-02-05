using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public struct CellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate<TTo>
    where TFrom : ICellCoordinate<TFrom>
  {
    private readonly long myCellsCount;
    private readonly ICellCoordinateSystemConverter<TFrom, TTo> myConverter;
    private readonly IEnumerable<TFrom> myCells;
    private readonly ICellImageBuilder<TTo> myCellImageBuilder;
    private readonly CellImageBuilderContext<TTo> myCellImageBuilderContext;

    public CellProcessorContext(long cellsCount, IEnumerable<TFrom> cells, ICellCoordinateSystemConverter<TFrom, TTo> converter, ICellImageBuilder<TTo> cellImageBuilder, CellImageBuilderContext<TTo> cellImageBuilderContext)
    {
      myCellsCount = cellsCount;
      myConverter = converter;
      myCells = cells;
      myCellImageBuilder = cellImageBuilder;
      myCellImageBuilderContext = cellImageBuilderContext;
    }

    public long CellsCount
    {
      get { return myCellsCount; }
    }

    public IEnumerable<TFrom> Cells
    {
      get { return myCells; }
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