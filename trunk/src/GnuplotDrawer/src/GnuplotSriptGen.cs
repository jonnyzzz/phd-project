using System;

namespace DSIS.GnuplotDrawer
{
  public static class GnuplotSriptGen
  {
    public static IGnuplotScriptGen ScriptGen(int dim, string filename,GnuplotScriptParameters ps)
    {
      if (dim == 2)
        return new Gnuplot2dScriptGen(filename, ps);
      else if (dim == 3)
        return new Gnuplot3dScriptGen(filename, ps);

      throw new ArgumentException("Unexpected value", "dim");
    }
  }
}