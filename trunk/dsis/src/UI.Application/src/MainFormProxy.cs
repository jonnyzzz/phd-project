using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.Application.Actions;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [ComponentImplementation]
  public class MainFormProxy : IMainForm
  {
    [Autowire]
    private XmlActionPreesentationManager myPresentation { get; set; }

    [Autowire]
    private ITypeInstantiator Instanciator { get; set; }

    private MainForm myForm;
    private bool myIsUnderCreateForm;

    public event EventHandler BeforeFormCreated;
    public event EventHandler AfterFormCreated;

    public Form GetForm()
    {
      return GetFormInternal();
    }

    private MainForm GetFormInternal()
    {
      if (myForm == null)
      {
        if (myIsUnderCreateForm)
        {
          throw new ArgumentException(
            "Infinite recursion. It is not allowed to use IMainForm methods from BeforeFormCreated event handler");
        }
        myIsUnderCreateForm = true;
        try
        {
          FireBeforeFormCreated();

          DoCreateForm();

          FireAfterFormCreated();
        } finally
        {
          myIsUnderCreateForm = false;
        }
      }
      return myForm;
    }

    private void DoCreateForm()
    {
      myPresentation.LoadAssembly(GetType().Assembly);
      myForm = Instanciator.Instanciate<MainForm>();
      myForm.Shown += delegate { myForm.Activate(); };
    }

    private void FireAfterFormCreated()
    {
      if (AfterFormCreated != null)
        AfterFormCreated(this, EventArgs.Empty);
    }

    private void FireBeforeFormCreated()
    {
      if (BeforeFormCreated != null)
        BeforeFormCreated(this, EventArgs.Empty);
    }

    public void SetContent(IControlWithTitle control)
    {
      var form = GetFormInternal();      
      form.MainContent = control.Control;
      form.Text = control.Title;
    }
  }
}