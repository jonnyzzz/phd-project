namespace DSIS.GnuplotDrawer
{
  public class Gnuplot2dScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public Gnuplot2dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename, @params)
    {
      myWriter.Write("plot ");
    }

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.Filename, string.Format("Count {0}", file.PointsCount));

      if (file.PointsCount >= 300)
        myWriter.Write(" dots ");
      else
        myWriter.Write(" points ");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }
  }
}