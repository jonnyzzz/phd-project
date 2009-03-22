using System.Collections.Generic;

namespace DSIS.GnuplotDrawer
{
  public interface IGnuplotScriptGen 
  {
    IGnuplotScript CloseFile();    
  }

  public interface IGnuplotFile
  {
    string FileName { get; }
  }

  public interface IGnuplotScript : IGnuplotFile
  {
  }

  public interface IGnuplotPointsFile : IGnuplotFile
  {    
    long PointsCount { get; }
  }

  public interface IGnuplotPhaseScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(IGnuplotPointsFile file);
  }

  public interface IGnuplotLineFile : IGnuplotFile
  {
    string Name { get; }
  }

  public interface IGnuplotLineScriptGen : IGnuplotScriptGen
  {
    void AddSeria(string name, IEnumerable<double> values);
    void AddFile(IGnuplotLineFile file);
  }
}