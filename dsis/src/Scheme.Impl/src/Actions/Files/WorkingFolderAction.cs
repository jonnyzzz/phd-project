using System;
using System.IO;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class WorkingFolderAction : WorkingFolderActionBase
  {
    protected override string CreateWorkPath(string resultsPath)
    {
      return Path.Combine(resultsPath, DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss"));
    }
  }
}