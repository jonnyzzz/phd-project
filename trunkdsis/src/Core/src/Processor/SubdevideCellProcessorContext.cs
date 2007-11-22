using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class SubdevideCellProcessorContext<T> : CellProcessorContextBase<T, T>, ICellProcessorMultiplyContext<T>
    where T : ICellCoordinate<T>
  {
    private readonly long[] myDivision;

    public SubdevideCellProcessorContext(ICountEnumerable<T> countEnumerable, ICellCoordinateSystem<T> system,
                                         long[] subdivision, ICellImageBuilder<T> cellImageBuilder,
                                         CellImageBuilderContext<T> cellImageBuilderContext)
      : base(countEnumerable, system.Subdivide(subdivision), cellImageBuilder, cellImageBuilderContext)
    {
      myDivision = subdivision;
    }

    public long[] Division
    {
      get { return myDivision; }
    }


    public SubdevideCellProcessorContext<T> CreateNextContext(CountEnumerable<T> input,
                                                              ICellCoordinateSystem<T> system,
                                                              long[] subdivision,
                                                              ICellConnectionBuilder<T> builder)
    {
      return new SubdevideCellProcessorContext<T>(input, system, subdivision, CellImageBuilder,
                                                  CellImageBuilderContext.NextStep(Converter.ToSystem, builder));
    }
  }
}