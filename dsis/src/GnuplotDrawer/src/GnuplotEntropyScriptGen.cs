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

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.Filename, string.Format("Count {0}", file.PointsCount));

      myWriter.Write(" points ");

      myWriter.Write(" palette ");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }
  }
}