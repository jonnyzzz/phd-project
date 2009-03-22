using System;

namespace DSIS.GnuplotDrawer
{ 
  public static class GnuplotSriptGen
  {
    public static IGnuplotPhaseScriptGen ScriptGen(int dim, string filename, GnuplotScriptParameters ps)
    {
      switch (dim)
      {
        case 1:
          return new Gnuplot1dScriptGen(filename, ps);
        case 2:
          return new Gnuplot2dScriptGen(filename, ps);
        case 3:
          return new Gnuplot3dScriptGen(filename, ps);
      }

      throw new ArgumentException("Unexpected value", "dim");
    }

    public static IGnuplotPhaseScriptGen Entrorpy2d(string filename, GnuplotScriptParameters param)
    {
      return new GnuplotEntropyScriptGen(filename, param);
    }

    public static IGnuplotLineScriptGen CreateLines(string filename, GnuplotScriptParameters ps)
    {
      return new LinesScriptGen(filename, ps);
    } 
  }
}