using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DSIS.UI.UI
{
  public delegate T WithForm<T>(Form form);

  public delegate void WithForm(Form form);

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

  public interface IApplicationClass
  {
    T ShowDialog<T>(WithForm<T> action);
    void ShowDialog(WithForm action);

//    IApplicationDocument Document { get; set; }
//    event EventHandler<DocumentChangedEventArgs> DocumentChanging;
  }
}