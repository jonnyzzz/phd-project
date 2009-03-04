using System;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [Used("si.xml")]
  public class DateWorkingFolderAction : PrefixWorkingFolderAction
  {
    protected override string Prefix(Context ctx)
    {
      return DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
    }
  }
}