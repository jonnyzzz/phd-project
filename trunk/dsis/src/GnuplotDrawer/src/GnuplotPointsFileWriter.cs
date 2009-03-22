namespace DSIS.GnuplotDrawer
{
  public class GnuplotPointsFileWriter : GnuplotPointsFileWriter<IGnuplotPointsFile>
  {
    public GnuplotPointsFileWriter(string filename, int dim) : base(filename, dim)
    {
    }

    protected override IGnuplotPointsFile CreateCloseInfo(string filename)
    {
      return new GnuplotPointFile { FileName = filename, PointsCount = PointsCount };
    }
    private class GnuplotPointFile : IGnuplotPointsFile
    {
      public string FileName { get; set; }
      public long PointsCount { get; set; }
    }
    
  }
}