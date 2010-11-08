using System.IO;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class FlatWorkingFolder : WorkingFolderActionBase
  {
    protected override string CreateWorkPath(string resultsPath)
    {
      return Path.Combine(resultsPath, "@Flat.LeonovP20_0.x");
    }
  }
}