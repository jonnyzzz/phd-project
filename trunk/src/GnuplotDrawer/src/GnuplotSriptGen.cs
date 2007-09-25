using System;

namespace DSIS.GnuplotDrawer
{ 
  public static class GnuplotSriptGen
  {
    public static IGnuplotPhaseScriptGen ScriptGen(int dim, string filename, GnuplotScriptParameters ps)
    {
      if (dim == 2)
        return new Gnuplot2dScriptGen(filename, ps);
      else if (dim == 3)
        return new Gnuplot3dScriptGen(filename, ps);

      throw new ArgumentException("Unexpected value", "dim");
    }

    public static IGnuplotPhaseScriptGen Entrorpy2d(string filename, GnuplotScriptParameters param)
    {
      return new GnuplotEntropyScriptGen(filename, param);
    }

    public static IGnuplotScriptGen CutGen(int dim, string filename, GnuplotScriptParameters ps)
    {
      return new MergedGnuplotScriptGen(ScriptGen(dim, filename, ps));
    }

    public static IGnuplotLineScriptGen CreateLines(string filename, GnuplotScriptParameters ps)
    {
      return new LinesScriptGen(filename, ps);
    } 
  }
}