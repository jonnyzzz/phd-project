using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public static class FileKeys
  {
    public static readonly Key<WorkingFolderInfo> WorkingFolderKey = new Key<WorkingFolderInfo>("working_folder");
    public static readonly Key<Logger> LoggerKey = new Key<Logger>("");
  }
}