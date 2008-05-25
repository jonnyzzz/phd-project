using System.Windows.Forms;
using DSIS.Spring;

namespace DSIS.UI.Application
{
  [UsedBySpring]
  public class ApplicationClass : IApplicationEntryPoint
  {
    private readonly IMainForm myMainForm;

    public ApplicationClass(IMainForm mainForm)
    {
      myMainForm = mainForm;
    }

    public int Main(string[] args)
    {
      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
      System.Windows.Forms.Application.Run(myMainForm.GetFrom());

//        new WizardForm(new SystemFunctionSelectionWizard()));
      //          new SimpleWizard(new[]
      //                             {new EmptyWizardPage(), new EmptyWizardPage()}){Title = "ZZZ"}) /*new MainForm()*/);

      return 0;
    }

    public delegate T WithForm<T>(Form form);
    public delegate void WithForm(Form form);

    public T ShowDialog<T>(WithForm<T> action)
    {
      return action(MainForm());
    }

    public void ShowDialog(WithForm action)
    {
      action(MainForm());
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