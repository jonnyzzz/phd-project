using System;
using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{ 
  public static class GnuplotSriptGen
  {
    public static IGnuplotPhaseScriptGen ScriptGen(int dim, ITempFileFactory factory, GnuplotScriptParameters ps)
    {
      switch (dim)
      {
        case 1:
          return new Gnuplot1dScriptGen(factory, ps);
        case 2:
          return new Gnuplot2dScriptGen(factory, ps);
        case 3:
          return new Gnuplot3dScriptGen(factory, ps);
      }

      throw new ArgumentException("Unexpected value", "dim");
    }

    public static IGnuplotPhaseScriptGen Entrorpy2d(ITempFileFactory factory, GnuplotScriptParameters param)
    {
      return new GnuplotEntropyScriptGen(factory, param);
    }

    public static IGnuplotLineScriptGen CreateLines(ITempFileFactory factory, GnuplotScriptParameters ps)
    {
      return new LinesScriptGen(factory, ".gnuplot", ps);
    } 
  }
}