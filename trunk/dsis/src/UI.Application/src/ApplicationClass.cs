using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.Ex;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class ApplicationClass : IApplicationClass, IApplication
  {
    private readonly IMainForm myMainForm;
    private IApplicationDocument myDocument;

    public event EventHandler<DocumentChangedEventArgs> DocumentChanged;
    
    public ApplicationClass(IMainForm mainForm, ConfigureWindowsForms _, IInvocator invocator)
    {
      Invocator = invocator;
      myMainForm = mainForm;
    }

    private IInvocator Invocator { get; set;}

    public int Main()
    {
      System.Windows.Forms.Application.Run(myMainForm.GetFrom());
      return 0;
    }

    public T ShowDialog<T>(Func<Form, T> action)
    {
      return action(MainForm);
    }

    public void ShowDialog(Action<Form> action)
    {
      action(MainForm);
    }

    public IApplicationDocument Document
    {
      get { return myDocument; }
      set { 
        if (myDocument != value)
        {
          var old = myDocument;
          myDocument = value;

          Invocator.InvokeOrQueue("Document changeg", () => FireDocumentChanged(old, myDocument));
        }
      }
    }

    private void FireDocumentChanged(IApplicationDocument oldDocument, IApplicationDocument newDocument)
    {
      DocumentChanged.Fire(this, new DocumentChangedEventArgs(oldDocument, newDocument));
    }

    public void OnMenuExit()
    {
      MainForm.Close();
    }

    private Form  MainForm
    {
      get { return myMainForm.GetFrom(); }
    }
  }
}