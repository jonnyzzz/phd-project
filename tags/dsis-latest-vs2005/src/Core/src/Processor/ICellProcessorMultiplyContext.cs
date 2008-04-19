using DSIS.Core.Coordinates;

namespace DSIS.Core.Processor
{
  public interface ICellProcessorMultiplyContext<T> : ICellProcessorContext<T,T> 
    where T : ICellCoordinate
  {
    long[] Division { get; }
  }
}