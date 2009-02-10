using System;
using System.Reflection;
using System.Windows.Forms;
using DSIS.Core.Ioc.Ex;
using DSIS.Utils;

namespace DSIS.UI.Application
{
  [Used]
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
      try
      {
        if (Assembly.Load(new AssemblyName("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")) == null)
          throw new Exception("Null");
      } catch
      {
        MessageBox.Show("Failed to find Microsoft .NET Framework 3.5. Please install it from http://download.microsoft.com",
                        "DSIS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return -1;
      }

      return ApplicationEntryPoint<ApplicationClass>.DoMain(args);
    }
  }
}