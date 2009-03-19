using System;
using DSIS.Core.Util;

namespace DSIS.UI.Application.Progress
{
  public interface IContextOperationExecution
  {
    void ExecuteAsync(string name, Action<IContextOperation, IProgressInfo> action);
  }
}