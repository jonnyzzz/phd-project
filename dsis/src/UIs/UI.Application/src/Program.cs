using System;
using System.Reflection;
using System.Windows.Forms;
using DSIS.CodeCompiler;
using DSIS.Utils;
using EugenePetrenko.Core.Ioc.EntryPoint;

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
      CodeCompilerFilenameGenerator.DeleteAllGeneratedFiles();

      System.Windows.Forms.Application.EnableVisualStyles();
      System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
      

      return ApplicationEntryPoint<ApplicationClass>.DoMain(args);
    }
  }
}