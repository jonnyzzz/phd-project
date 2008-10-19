using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.Ex;
using DSIS.Spring;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [UsedBySpring, ComponentImplementation]
  public class ApplicationClass : IApplicationClass, IApplication
  {
    private readonly IMainForm myMainForm;
    private IApplicationDocument myDocument;

    public event EventHandler<DocumentChangedEventArgs> DocumentChanged;
    
    public ApplicationClass(IMainForm mainForm)
    {
      myMainForm = mainForm;
    }

    public int Main()
    {
      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
      System.Windows.Forms.Application.Run(myMainForm.GetFrom());

      return 0;
    }

    public T ShowDialog<T>(WithForm<T> action)
    {
      return action(MainForm());
    }

    public void ShowDialog(WithForm action)
    {
      action(MainForm());
    }

    public IApplicationDocument Document
    {
      get { return myDocument; }
      set { 
        if (myDocument != value)
        {
          var old = myDocument;
          myDocument = value;
          FireDocumentChanged(old, myDocument);
        }
      }
    }

    private void FireDocumentChanged(IApplicationDocument oldDocument, IApplicationDocument newDocument)
    {
      if (DocumentChanged != null)
      {
        DocumentChanged(this, new DocumentChangedEventArgs(oldDocument, newDocument));
      }
    }

    public void OnMenuExit()
    {
      MainForm().Close();
    }

    private Form MainForm()
    {
      return myMainForm.GetFrom();
    }
  }
}