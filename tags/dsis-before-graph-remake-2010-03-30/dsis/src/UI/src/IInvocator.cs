using System;

namespace DSIS.UI.UI
{
  public interface IInvocator
  {
    void InvokeOrQueue(string name, Action action);

    IDisposable ExecuteWithTimeout(string name, TimeSpan interval, Action action);
    IDisposable ExecuteRepeating(string name, TimeSpan interval, Action action);
  }
}