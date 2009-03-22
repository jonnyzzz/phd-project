namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotEntropyScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(IGnuplotPointsFile entropy, IGnuplotPointsFile @base);
  }
}