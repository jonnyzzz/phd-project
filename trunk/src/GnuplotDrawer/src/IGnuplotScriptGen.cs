namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotScriptGen
  {
    void AddPointsFile(GnuplotPointsFileWriter file);
    void Dispose();

    string Filename { get; }
  }
}