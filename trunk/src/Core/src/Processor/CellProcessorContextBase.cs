using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public abstract class CellProcessorContextBase<TFrom, TTo> : ICellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate<TTo>
    where TFrom : ICellCoordinate<TFrom>
  {
    private readonly ICellCoordinateSystemConverter<TFrom, TTo> myConverter;
    private readonly ICountEnumerable<TFrom> myCountEnumerable;
    private readonly ICellImageBuilder<TTo> myCellImageBuilder;
    private readonly CellImageBuilderContext<TTo> myCellImageBuilderContext;

    public CellProcessorContextBase(
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
  }
}