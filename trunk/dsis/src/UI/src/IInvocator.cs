using System;

namespace DSIS.UI.UI
{
  public interface IInvocator
  {
    void InvokeOrQueue(string name, Action action);
  }
}