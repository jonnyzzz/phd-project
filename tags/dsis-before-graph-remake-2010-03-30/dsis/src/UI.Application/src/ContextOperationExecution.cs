using System;
using DSIS.Core.Ioc;
using DSIS.Core.Util;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [DocumentComponent]
  public class ContextOperationExecution : IContextOperationExecution
  {
    [Autowire]
    private IActionExecution Exec { get; set; }

    [Autowire]
    private DocumentManager DocumentManager { get; set; }

    public void ExecuteAsync(string name, Action<IContextOperation, IProgressInfo> action)
    {
      using (var cookie = DocumentManager.GetContextWriteOperation())
      {
        var dispose = cookie.WaitDispose();
        Exec.ExecuteAsync(name, pi =>
                                  {
                                    using (dispose)
                                    {
                                      action(cookie, pi);
                                    }
                                  });
      }
    }
  }
}