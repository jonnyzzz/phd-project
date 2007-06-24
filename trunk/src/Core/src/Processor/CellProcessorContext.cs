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
    private readonly ICountEnumerable<TFrom> myCountEnumerable;
    private readonly ICellImageBuilder<TTo> myCellImageBuilder;
    private readonly CellImageBuilderContext<TTo> myCellImageBuilderContext;

    public CellProcessorContext(
      ICountEnumerable<TFrom> countEnumerable,
      ICellCoordinateSystemConverter<TFrom, TTo> converter,
      ICellImageBuilder<TTo> cellImageBuilder,
      CellImageBuilderContext<TTo> cellImageBuilderContext)
    {
      myConverter = converter;
      myCountEnumerable = countEnumerable;
      myCellImageBuilder = cellImageBuilder;
      myCellImageBuilderContext = cellImageBuilderContext;
    }

    public ICountEnumerable<TFrom> Cells
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