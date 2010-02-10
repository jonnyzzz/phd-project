using System;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DateWorkingFolderAction : PrefixWorkingFolderAction
  {
    protected override string Prefix(Context ctx)
    {
      return DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
    }
  }
}