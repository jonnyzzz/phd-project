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
      return ApplicationEntryPoint.DoMain(args);
//      return SpringIoCSetup.AsMain<ApplicationClass>(args);      
    }
  }
}