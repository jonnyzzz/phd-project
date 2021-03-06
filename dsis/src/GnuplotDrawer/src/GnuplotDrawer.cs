using System;
using System.Diagnostics;
using System.IO;
using EugenePetrenko.Shared.Core.Ioc.Api;

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

    /// <summary>
    /// Executes gnuplot command. 
    /// </summary>
    /// <param name="script"></param>
    /// <returns>GnuPlot running process</returns>
    /// <exception cref="GnuplotDrawException">if gnuplot process was not found or failed to start</exception>
    public Process DrawImage(IGnuplotScript script)
    {
      try
      {
        var pi = new ProcessStartInfo
                   {
                     FileName = GetWGnuplotPath(),
                     Arguments = script.FileName,
                     ErrorDialog = true,
                     UseShellExecute = true,
                   };

        if (!File.Exists(pi.FileName))
          throw new GnuplotDrawException("Unable to locate pgnuplot.exe");

        return Process.Start(pi);
      } catch (Exception e)
      {
        throw new GnuplotDrawException("Gnuplot process failed to start. " + e.Message, e);
      }
    }

    private string GetWGnuplotPath()
    {
      foreach (var path in new[]{"bin\\wgnuplot.exe", "binary\\gnuplot.exe"})
      {
        var exe = Path.Combine(myGnuplotFolder, path);
        if (File.Exists(exe))
          return exe;
      }

      throw new GnuplotDrawException("Failed to find bin/wgnuplot.exe or binary/gnuplot.exe under gnuplot home: " + myGnuplotFolder);
    }
  }
}