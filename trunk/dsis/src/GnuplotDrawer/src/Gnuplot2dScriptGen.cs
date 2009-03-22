using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class Gnuplot2dScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public Gnuplot2dScriptGen(ITempFileFactory factory, GnuplotScriptParameters @params) : base(factory, @params)
    {
      myWriter.Write("plot ");
    }

    public void AddPointsFile(IGnuplotPointsFile file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.FileName, string.Format("Count {0}", file.PointsCount));

      if (myParams.ForcePoints || file.PointsCount >= 300)
        myWriter.Write(" dots ");
      else
        myWriter.Write(" points ");
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }
  }
}