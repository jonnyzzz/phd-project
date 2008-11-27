using System.Collections.Generic;

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

  public interface IGnuplotLineScriptGen : IGnuplotScriptGen
  {
    string AddSeria(string name, IEnumerable<double> values);
    void AddFile(string file, string title);
  }
}