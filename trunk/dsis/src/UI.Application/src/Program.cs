using System;
using DSIS.UI.Application;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
      System.Windows.Forms.Application.Run(
        new WizardForm(
          new SimpleWizard(new[]
                             {new EmptyWizardPage(), new EmptyWizardPage()}){Title = "ZZZ"}) /*new MainForm()*/);
    }
  }
}