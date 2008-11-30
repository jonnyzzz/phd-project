using System;
using DSIS.Core.Ioc.Ex;

namespace DSIS.UI.Application
{
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static int Main(string[] args)
    {
      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

      return ApplicationEntryPoint.DoMain(args);
    }
  }
}