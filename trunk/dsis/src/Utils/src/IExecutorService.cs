using System;

namespace DSIS.Utils
{
  public interface IExecutorService
  {
    IExecutingAction Execute(string name, Action<IExecutingAction> action);

    int Pending { get; }

    /// <summary>
    /// Clear wait queue.
    /// Interrupt pending task
    /// </summary>
    void TerminateAll();
  }

  public interface IExecutingAction
  {
    /// <summary>
    /// Removes action from Queue
    /// </summary>
    void Cancel();
  }
}