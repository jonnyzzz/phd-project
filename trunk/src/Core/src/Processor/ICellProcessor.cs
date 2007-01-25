/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;

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
  }

  /// <summary>
  /// This interface denotes a process for ICellImageBuilder that
  /// was Initialized by the call of Bind method
  /// </summary>
  /// <typeparam name="TCellFrom"></typeparam>
  /// <typeparam name="TCellTo"></typeparam>
  public interface ICellProcessor<TCellFrom, TCellTo> : IProcess
    where TCellFrom : ICellCoordinate<TCellFrom>
    where TCellTo : ICellCoordinate<TCellTo>
  {
    void Bind(CellProcessorContext<TCellFrom, TCellTo> context);

  }
}