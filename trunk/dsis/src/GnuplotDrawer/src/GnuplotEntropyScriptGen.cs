namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropyScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropyScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {
      myWriter.WriteLine("set view map;");
      myWriter.Write("splot ");
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }

    public void AddPointsFile(IGnuplotPointsFile file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.FileName, string.Format("Count {0}", file.PointsCount));

      myWriter.Write(" points ");

      myWriter.Write(" palette ");
    }
  }
}