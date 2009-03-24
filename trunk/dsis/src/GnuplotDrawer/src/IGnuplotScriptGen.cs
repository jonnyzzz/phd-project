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

  public interface IGnuplotMeasureDensityFile : IGnuplotFile
  {
  }

  public interface IGnuplotPhaseScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(IGnuplotPointsFile file);
  }

  public interface IGnuplotMeasureDensityScriptGen : IGnuplotScriptGen
  {
    void AddPointsFile(IGnuplotMeasureDensityFile file);
  }

  public interface IGnuplotMeasureDensityScriptGen2 : IGnuplotScriptGen
  {
    void AddPointsFile(IGnuplotPointsFile entropy, IGnuplotPointsFile @base);
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