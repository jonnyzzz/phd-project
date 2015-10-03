using System;
using DSIS.Spring;

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
      return SpringIoCSetup.AsMain<ApplicationClass>(args);      
    }
  }
}