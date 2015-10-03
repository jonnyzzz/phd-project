using System;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public abstract class CellProcessorContextBase<TFrom, TTo> : ICellProcessorContext<TFrom, TTo>
    where TTo : ICellCoordinate
    where TFrom : ICellCoordinate
  {
    private readonly ICellCoordinateSystemConverter<TFrom, TTo> myConverter;
    private readonly ICellCoordinateCollection<TFrom> myCountEnumerable;
    private readonly ICellImageBuilder<TTo> myCellImageBuilder;
    private readonly CellImageBuilderContext<TTo> myCellImageBuilderContext;

    protected CellProcessorContextBase(
      ICellCoordinateCollection<TFrom> countEnumerable,
      ICellCoordinateSystemConverter<TFrom, TTo> converter,
      ICellImageBuilder<TTo> cellImageBuilder,
      CellImageBuilderContext<TTo> cellImageBuilderContext)
    {
      myConverter = converter;
      myCountEnumerable = countEnumerable;
      myCellImageBuilder = cellImageBuilder;
      myCellImageBuilderContext = cellImageBuilderContext;

      if (!countEnumerable.System.Equals(converter.FromSystem))
      {
        throw new ArgumentException("Cells coordinate system should match converter from system");
      }
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