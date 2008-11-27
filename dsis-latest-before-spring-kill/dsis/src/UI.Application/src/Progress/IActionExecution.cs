using System;
using DSIS.Core.Util;

namespace DSIS.UI.Application.Progress
{
  public interface IActionExecution
  {
    void ExecuteAsync(string name, Action<IProgressInfo> action);
  }
}