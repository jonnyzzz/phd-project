/*
 * Created by: Eugene Petrenko
 * Created: 18 но€бр€ 2006 г.
 */

using DSIS.Core.Coordinates;

namespace DSIS.Core.Processor
{
  /// <summary>
  /// This interface denotes a process for ICellImageBuilder that
  /// was Initialized by the call of Bind method
  /// </summary>
  /// <typeparam name="TCellFrom"></typeparam>
  /// <typeparam name="TCellTo"></typeparam>
  public interface ICellProcessor<TCellFrom, TCellTo> : IProcess
    where TCellFrom : ICellCoordinate
    where TCellTo : ICellCoordinate
  {
    void Bind(ICellProcessorContext<TCellFrom, TCellTo> context);
  }

  public interface ICellProcessor<T> : IProcess 
    where T : ICellCoordinate
  {
    void Bind(ICellProcessorMultiplyContext<T> context);
  }
}