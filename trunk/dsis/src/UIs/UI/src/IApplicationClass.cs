using System;
using System.ComponentModel;
using System.Windows.Forms;
using DSIS.Core.Ioc;

namespace DSIS.UI.UI
{
  public class DocumentChangedEventArgs : CancelEventArgs
  {
    public readonly IApplicationDocument OldDocument;
    public readonly IApplicationDocument NewDocument;

    public DocumentChangedEventArgs(IApplicationDocument oldDocument, IApplicationDocument newDocument)
    {
      OldDocument = oldDocument;
      NewDocument = newDocument;
      Cancel = false;
    }
  }

  [ComponentInterface]
  public interface IApplicationClass
  {
    T ShowDialog<T>(Func<Form, T> action);
    void ShowDialog(Action<Form> action);

    IApplicationDocument Document { get; set; }
    event EventHandler<DocumentChangedEventArgs> DocumentChanged;
    void OnMenuExit();
  }
}