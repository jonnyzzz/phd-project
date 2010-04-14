using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class LinePointsFile : GnuplotPointsFileWriter<IGnuplotLineFile>
  {
    private readonly string myName;

    public LinePointsFile(ITempFileFactory factory, string suffix, int dim, string name) : base(factory, suffix, dim)
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