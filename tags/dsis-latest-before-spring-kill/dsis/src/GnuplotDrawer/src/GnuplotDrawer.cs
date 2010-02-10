using System;
using System.Diagnostics;
using System.IO;
using DSIS.Core.Ioc;

namespace DSIS.GnuplotDrawer
{
  [ComponentImplementation]
  public class GnuplotDrawer
  {
    private readonly string myGnuplotFolder;

    private static string EvalPath2Gnuplot()
    {
      string pathBase = Path.GetDirectoryName(typeof (GnuplotDrawer).Assembly.Location);
      while (pathBase != null)
      {
        string test = Path.Combine(pathBase, @"tools\gnuplot");
        test = Path.GetFullPath(test);
        if (Directory.Exists(test))
          return test;
        pathBase = Path.GetDirectoryName(pathBase);
      }
      return null;
    }

    public GnuplotDrawer() : this(EvalPath2Gnuplot())
    {
    }

    private GnuplotDrawer(string gnuplotFolder)
    {
      myGnuplotFolder = gnuplotFolder;
    }

    public Process DrawImage(IGnuplotScript script)
    {

      var pi = new ProcessStartInfo
                              {
                                FileName = Path.Combine(myGnuplotFolder, @"bin\wgnuplot.exe"),
                                Arguments = script.Filename,
                                ErrorDialog = true,
                                UseShellExecute = true,                                
                              };

      if (!File.Exists(pi.FileName))
        throw new ArgumentException("Unable to locate pgnuplot.exe");

      return Process.Start(pi);
    }
  }
}