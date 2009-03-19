using System;

namespace DSIS.UI.Application
{
  public interface IDocumentManager
  {
    event EventHandler<OperationEventArgs> OperationTaken;
  }

  public class OperationEventArgs : EventArgs
  {
    public readonly bool IsOperationTaken;

    public OperationEventArgs(bool isOperationTaken)
    {
      IsOperationTaken = isOperationTaken;
    }
  }
}