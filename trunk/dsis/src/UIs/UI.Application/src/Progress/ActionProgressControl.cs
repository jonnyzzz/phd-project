using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Core.Util;
using DSIS.UI.Application.Doc;
using DSIS.UI.Controls;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  [DocumentComponent]
  public class ActionProgressControl : IDocumentControl, IDocumentComponent, IActionExecution
  {
    private readonly ActionExecutorProgressControl myControl;
    public ActionProgressControl(ITypeInstantiator typeInstantiator)
    {
      myControl = typeInstantiator.Instanciate<ActionExecutorProgressControl>(new OneTreadExecutor());
    }

    public string Ancor
    {
      get { return "ZZZZ"; }
    }

    public Layout[] Float
    {
      get { return new[] {Layout.LEFT, Layout.BOTTON,}; }
    }

    Control IControlWithLayout2.Control
    {
      get { return myControl.Control; }
    }

    public void BeforeDocumentContainerDisposed()
    {
      myControl.BeforeDocumentContainerDisposed();
    }

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      myControl.ExecuteAsync(name, action);
    }
  }
}