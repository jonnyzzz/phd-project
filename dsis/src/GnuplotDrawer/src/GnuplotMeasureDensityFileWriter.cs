using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotMeasureDensityFileWriter : GnuplotPointsFileWriter<IGnuplotMeasureDensityFile>
  {
    public GnuplotMeasureDensityFileWriter(ITempFileFactory factory, string suffix, int dim) : base(factory, suffix, dim)
    {
    }

    protected override IGnuplotMeasureDensityFile CreateCloseInfo(string filename)
    {
      return new GnuplotPointFile { FileName = filename};
    }
    private class GnuplotPointFile : IGnuplotMeasureDensityFile
    {
      public string FileName { get; set; }
    }
  }
}