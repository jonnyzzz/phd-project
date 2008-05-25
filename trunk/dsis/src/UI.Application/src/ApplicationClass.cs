using System.Windows.Forms;
using DSIS.Spring;
using DSIS.UI.UI;

namespace DSIS.UI.Application
{
  [UsedBySpring]
  public class ApplicationClass : IApplicationEntryPoint, IApplicationClass
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