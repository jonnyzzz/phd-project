using System;
using System.Windows.Forms;
using DSIS.Core.Ioc.Ex;
using DSIS.Spring;
using DSIS.UI.Application.Doc;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [UsedBySpring]
  public class ApplicationClass : IApplicationEntryPoint, IApplicationClass, IApplication
  {
    private readonly IMainForm myMainForm;
    private IApplicationDocument myDocument;

    public event EventHandler<DocumentChangedEventArgs> DocumentChanged;
    
    public ApplicationClass(IMainForm mainForm)
    {
      myMainForm = mainForm;

      myMainForm.GetFrom().Controls.Add(new CurrentDocumentControl(this){Dock = DockStyle.Fill});
    }

    public int Main()
    {
      return Main(new[0]);
    }

    public int Main(string[] args)
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