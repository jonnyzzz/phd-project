using System;
using DSIS.Spring;
using DSIS.UI.FunctionDialog;
using DSIS.UI.Wizard;

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
      Log4NetConfigurator.SetUp();
      SpringIoCSetup.SetUp();

      return SpringIoC.Instance.Main(args);      
    }
  }
}