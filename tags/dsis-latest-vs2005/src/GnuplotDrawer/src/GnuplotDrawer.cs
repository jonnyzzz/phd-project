using System;
using System.Diagnostics;
using System.IO;

namespace DSIS.GnuplotDrawer
{
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

    public GnuplotDrawer(string gnuplotFolder)
    {
      myGnuplotFolder = gnuplotFolder;
    }

    public void DrawImage(IGnuplotScript script)
    {
      ProcessStartInfo pi = new ProcessStartInfo();
      pi.FileName = Path.Combine(myGnuplotFolder, @"bin\pgnuplot.exe");

      if (!File.Exists(pi.FileName))
        throw new ArgumentException("Unable to locate pgnuplot.exe");

      pi.Arguments = script.Filename;
      pi.CreateNoWindow = true;
      pi.WindowStyle = ProcessWindowStyle.Hidden;
      
      Process ps = Process.Start(pi);
      ps.WaitForExit();
    }
  }
}