namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotEntropyScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(GnuplotPointsFileWriter entropy, GnuplotPointsFileWriter @base);
  }
}