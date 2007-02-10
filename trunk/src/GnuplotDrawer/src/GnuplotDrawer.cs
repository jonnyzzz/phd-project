using System.Diagnostics;
using System.IO;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotDrawer
  {
    private readonly string myGnuplotFolder;

    public GnuplotDrawer(string gnuplotFolder)
    {
      myGnuplotFolder = gnuplotFolder;
    }

    public void DrawImage(IGnuplotScriptGen script)
    {
      ProcessStartInfo pi = new ProcessStartInfo();
      pi.FileName = Path.Combine(myGnuplotFolder, @"bin\pgnuplot.exe");
      pi.Arguments = script.Filename;

      Process ps = Process.Start(pi);
      ps.WaitForExit();
    }
  }
}
