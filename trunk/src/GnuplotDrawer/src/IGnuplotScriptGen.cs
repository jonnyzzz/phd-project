namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotScript
  {
    string Filename { get; }
  }

  public interface IGnuplotScriptGen : IGnuplotScript
  {
    void Finish();    
  }

  public interface IGnuplotPhaseScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(GnuplotPointsFileWriter file);    
  }
}