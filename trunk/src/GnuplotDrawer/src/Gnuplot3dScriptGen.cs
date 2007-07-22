namespace DSIS.GnuplotDrawer
{
  public class Gnuplot3dScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public Gnuplot3dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename, @params)
    {
      myWriter.Write("splot ");
    }

    #region IGnuplotScriptGen Members

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

    #endregion
  }
}