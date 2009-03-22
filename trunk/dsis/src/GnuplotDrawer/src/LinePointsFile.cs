namespace DSIS.GnuplotDrawer
{
  public class LinePointsFile : GnuplotPointsFileWriter<IGnuplotLineFile>
  {
    private readonly string myName;

    public LinePointsFile(string filename, int dim, string name) : base(filename, dim)
    {
      myName = name;
    }

    protected override IGnuplotLineFile CreateCloseInfo(string filename)
    {
      return new GnuplotLineFile {FileName = filename, Name = myName};
    }

    private class GnuplotLineFile : IGnuplotLineFile
    {
      public string FileName { get; set; }
      public string Name { get; set; }
    }
  }
}